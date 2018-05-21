//--------------ABOUT AND COPYRIGHT----------------------
// Copyright © 2013 SketchWork Productions Limited
//       support@sketchworkdev.com
//-------------------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This is the Slot machine main script and controls every element of the control.
/// </summary>
public class SWP_SlotMachine: MonoBehaviour
{		
	enum SoundType {SpinSound, StopSound, WinSound, NudgeUpSound, NudgeDownSound};

	public float PreSpinDuration = 2f;  // Number of seconds it will spin for before they start stopping.

	public bool EnableMiddleLineWin = true;
	public bool EnableTopLineWin = false;
	public bool EnableBottomLineWin = false;

	public List<SWP_InternalSlotReel> AllReels;

	public bool EnableFixSpin = false;

	public float SpeedModifier = 1000f;
	
	public delegate void OnReelStartEvent(GameObject e);
	public event OnReelStartEvent OnReelStart;
	
	public delegate void OnEachReelFinishedEvent(GameObject e, int _ReelNumber);
	public event OnEachReelFinishedEvent OnEachReelFinished;

	public delegate void OnReelsFinishedEvent(GameObject e);
	public event OnReelsFinishedEvent OnReelsFinished;
	
	public delegate void OnMiddleMatchEvent(GameObject e);
	public event OnMiddleMatchEvent OnMiddleMatch;
	
	public delegate void OnTopMatchEvent(GameObject e);
	public event OnTopMatchEvent OnTopMatch;
	
	public delegate void OnBottomMatchEvent(GameObject e);
	public event OnBottomMatchEvent OnBottomMatch;

	private bool InfinatelySpinIt = false;
	public bool IsSpinning = false;
	
	public bool EnableSound = true;
	public float SoundVolume = 1f;
	public AudioClip ReelSpinSound;
	public AudioClip ReelStopSound;
	public AudioClip ReelWinSound;
	public AudioClip ReelNudgeUpSound;
	public AudioClip ReelNudgeDownSound;

	void Start()
	{
		SetReelIncrements();
	}

	public void StartStopReels()
	{				
		if (IsSpinning)
			return;

		if (OnReelStart != null)
			OnReelStart(this.gameObject);

		SetReelIncrements();
		StartCoroutine(StartStopINum(false));
	}

	public void StartReels()
	{		
		if (IsSpinning)
			return;
		
		if (OnReelStart != null)
			OnReelStart(this.gameObject);
		
		SetReelIncrements();
		InfinatelySpinIt = true;
		StartCoroutine(StartStopINum(true));
	}
	
	public void StopReels()
	{		
		if (!IsSpinning)
			return;
		
		InfinatelySpinIt = false;
	}
	
	public void NudgeReels(bool _NudgeUp, int _Reel)
	{
		if (AllReels[_Reel].ReelRoot == null)
			throw new System.ArgumentException("Number of Reels = " + AllReels.Count.ToString() + ", but you have tried to nudge a invalid reel.");

		float thisOldRotation = AllReels[_Reel].ReelRotation;

		if (_NudgeUp)
			AllReels[_Reel].ReelRotation = (((AllReels[_Reel].ReelRotation + AllReels[_Reel].ReelIncrements) / 360f) % 1f) * 360f;
		else
			AllReels[_Reel].ReelRotation = (((AllReels[_Reel].ReelRotation - AllReels[_Reel].ReelIncrements) / 360f) % 1f) * 360f;

		if (AllReels[_Reel].ReelRotation < 0)
			AllReels[_Reel].ReelRotation += 360f;

		AllReels[_Reel].ReelRoot.transform.Rotate(new Vector3(AllReels[_Reel].ReelRotation - thisOldRotation, 0f, 0f));	

		PlaySlotSound(_NudgeUp ? SoundType.NudgeUpSound : SoundType.NudgeDownSound, 1f);

		AllReels[_Reel].CurrentReelValue = GetValue(AllReels[_Reel].ReelRotation, _Reel);

		ReelsFinishedRolling();
	}

	IEnumerator StartStopINum(bool _InfinitePreSpin)
	{
		IsSpinning = true;

		bool[] thisReelDone = new bool[AllReels.Count];
		float[] thisReelSpinDuration = new float[AllReels.Count];
		float thisOldRotation = 0f;
		
		for (int thisCounter = 0; thisCounter < (AllReels.Count); thisCounter++)
		{
			thisReelDone[thisCounter] = false;
			AllReels[thisCounter].CurrentReelValue = -1;
		}

		PlaySlotSound(SoundType.SpinSound, 1f);
		
		if (_InfinitePreSpin)
		{
			while (InfinatelySpinIt)
			{
				for (int thisCounter = 0; thisCounter < (AllReels.Count); thisCounter++)
				{
					if (AllReels[thisCounter].ReelRoot == null)
					{
						IsSpinning = false;
						throw new System.ArgumentException("Number of Reels = " + AllReels.Count.ToString() + ", but you have not assigned all the reel objects.");
					}
						
					if (!AllReels[thisCounter].ReelHeld)
					{
						thisOldRotation = AllReels[thisCounter].ReelRotation;
						AllReels[thisCounter].ReelRotation = NewRotation(AllReels[thisCounter].ReelRotation);
						AllReels[thisCounter].ReelRoot.transform.Rotate(new Vector3(-AllReels[thisCounter].ReelRotation + thisOldRotation, 0f, 0f));
					}
				}
			    			
				yield return null;
			}
		}
		
		float thisStartTime = Time.time; 
		float thisTimePassed = 0; 		
		
		if (_InfinitePreSpin)
			thisReelSpinDuration[0] = Random.Range(0.25f, 0.75f);
		else
			thisReelSpinDuration[0] = PreSpinDuration + Random.Range(0.25f, 0.75f);
		
		for (int thisCounter = 1; thisCounter < (AllReels.Count); thisCounter++) // i = 1 because we have already set the 0 part of the array
			thisReelSpinDuration[thisCounter] = thisReelSpinDuration[thisCounter-1] + Random.Range(0.25f, 0.75f);
		
		while (thisTimePassed < thisReelSpinDuration[AllReels.Count-1])
		{			
			thisTimePassed = Time.time - thisStartTime;
			
			for (int thisCounter = 0; thisCounter < (AllReels.Count); thisCounter++)
			{
				if (!AllReels[thisCounter].ReelHeld)
				{
					if (AllReels[thisCounter].ReelRoot == null)
					{
						IsSpinning = false;
						throw new System.ArgumentException("Number of Reels = " + AllReels.Count.ToString() + ", but you have not assigned all the reel objects.");
					}
						
					thisOldRotation = AllReels[thisCounter].ReelRotation;

					if (!thisReelDone[thisCounter] && thisTimePassed < thisReelSpinDuration[thisCounter])
					{					
						AllReels[thisCounter].ReelRotation = NewRotation(AllReels[thisCounter].ReelRotation);
						AllReels[thisCounter].ReelRoot.transform.Rotate(new Vector3(-AllReels[thisCounter].ReelRotation + thisOldRotation, 0f, 0f));
					}
					else if (!thisReelDone[thisCounter])
					{
						AllReels[thisCounter].ReelRotation = JumpToNearest(ref AllReels[thisCounter].ReelRotation, AllReels[thisCounter].FixedReelValue, thisCounter);
						AllReels[thisCounter].ReelRoot.transform.Rotate(new Vector3(-AllReels[thisCounter].ReelRotation + thisOldRotation, 0f, 0f));

						PlaySlotSound(SoundType.StopSound, 1f);

						AllReels[thisCounter].CurrentReelValue = GetValue(AllReels[thisCounter].ReelRotation, thisCounter);

						if (OnEachReelFinished != null)
							OnEachReelFinished(this.gameObject, thisCounter);

						thisReelDone[thisCounter] = true;
					}
				}
				else if (!thisReelDone[thisCounter])
				{
					AllReels[thisCounter].CurrentReelValue = GetValue(AllReels[thisCounter].ReelRotation, thisCounter);
					
					if (OnEachReelFinished != null)
						OnEachReelFinished(this.gameObject, thisCounter);
					
					thisReelDone[thisCounter] = true;
				}
			}
		    			
			yield return null;
		}
		
		ReelsFinishedRolling();
	}
	
	float NewRotation(float _OldRotation)
	{
		_OldRotation += Time.deltaTime * SpeedModifier;
		return ((_OldRotation / 360f) % 1f) * 360f;
	}

	float JumpToNearest(ref float _ReelRotation, int _FixSpin, int _Reel)
	{
		if (!EnableFixSpin)
		{
			float thisPosition = _ReelRotation / AllReels[_Reel].ReelIncrements;
			float thisRoundedValue = Mathf.Round(thisPosition);
			_ReelRotation = AllReels[_Reel].ReelIncrements * (thisRoundedValue * AllReels[_Reel].ReelIncrements == 360f ? 0f : thisRoundedValue);
			return _ReelRotation;
		}
		else
		{
			_ReelRotation = AllReels[_Reel].ReelIncrements * _FixSpin;
			return AllReels[_Reel].ReelIncrements * _FixSpin;
		}
	}
	
	int GetValue(float _ReelRotation, int _Reel)
	{
		return (int)(_ReelRotation / AllReels[_Reel].ReelIncrements);
	}
	
	void ReelsFinishedRolling()
	{
		bool thisMiddleMatching = true;
		bool thisTopMatching = true;
		bool thisBottomMatching = true;

		for (int thisCounter = 0; thisCounter < (AllReels.Count); thisCounter++)
		{
			if (EnableMiddleLineWin && thisMiddleMatching)
			{
				if (thisCounter == 0) // Always true for one reel
					thisMiddleMatching = true;
				else if (AllReels[thisCounter].GetMiddleReelItemValue() == AllReels[thisCounter - 1].GetMiddleReelItemValue())
					thisMiddleMatching = true;
				else
					thisMiddleMatching = false;
			}

			if (EnableTopLineWin && thisTopMatching)
			{
				if (thisCounter == 0) // Always true for one reel
					thisTopMatching = true;
				else if (AllReels[thisCounter].GetTopReelItemValue() == AllReels[thisCounter - 1].GetTopReelItemValue())
					thisTopMatching = true;
				else
					thisTopMatching = false;
			}

			if (EnableBottomLineWin && thisBottomMatching)
			{
				if (thisCounter == 0) // Always true for one reel
					thisBottomMatching = true;
				else if (AllReels[thisCounter].GetBottomReelItemValue() == AllReels[thisCounter - 1].GetBottomReelItemValue())
					thisBottomMatching = true;
				else
					thisBottomMatching = false;
			}
		}
		
		if ((EnableMiddleLineWin && thisMiddleMatching) || (EnableTopLineWin && thisTopMatching) || (EnableBottomLineWin && thisBottomMatching))
		{
			PlaySlotSound(SoundType.WinSound, 1f);
			
			if (EnableMiddleLineWin && thisMiddleMatching && OnMiddleMatch != null)
				OnMiddleMatch(this.gameObject);
			
			if (EnableTopLineWin && thisTopMatching && OnTopMatch != null)
				OnTopMatch(this.gameObject);
			
			if (EnableBottomLineWin && thisBottomMatching && OnBottomMatch != null)
				OnBottomMatch(this.gameObject);
		}

		if (OnReelsFinished != null)
			OnReelsFinished(this.gameObject);

		IsSpinning = false;
	}

	void PlaySlotSound(SoundType _SoundType, float _SoundVolume)
	{
		if (!EnableSound)
			return;
		
		if (_SoundType == SoundType.SpinSound && ReelSpinSound != null)
			GetComponent<AudioSource>().PlayOneShot(ReelSpinSound, _SoundVolume);
		else if (_SoundType == SoundType.StopSound && ReelStopSound != null)
			GetComponent<AudioSource>().PlayOneShot(ReelStopSound, _SoundVolume);
		else if (_SoundType == SoundType.WinSound && ReelWinSound != null)
			GetComponent<AudioSource>().PlayOneShot(ReelWinSound, _SoundVolume);
		else if (_SoundType == SoundType.NudgeDownSound && ReelWinSound != null)
			GetComponent<AudioSource>().PlayOneShot(ReelNudgeDownSound, _SoundVolume);
		else if (_SoundType == SoundType.NudgeUpSound && ReelWinSound != null)
			GetComponent<AudioSource>().PlayOneShot(ReelNudgeUpSound, _SoundVolume);
	}
	
	public string DisplayMiddleReelValues()
	{
		string thisMiddleReelValues = "Main Line Values: ";
		
		for (int thisCounter = 0; thisCounter < AllReels.Count; thisCounter++)
		{
			thisMiddleReelValues += AllReels[thisCounter].GetMiddleReelItemName() + " [" + AllReels[thisCounter].GetMiddleReelItemValue() + "]";
			
			if (AllReels.Count - 1 > thisCounter)
				thisMiddleReelValues += " / ";
		}
		
		return thisMiddleReelValues;
	}
	
	public string DisplayTopReelValues()
	{
		string thisTopReelValues = "Top Line Values: ";
		
		for (int thisCounter = 0; thisCounter < AllReels.Count; thisCounter++)
		{
			thisTopReelValues += AllReels[thisCounter].GetTopReelItemName() + " [" + AllReels[thisCounter].GetTopReelItemValue() + "]";
			
			if (AllReels.Count - 1 > thisCounter)
				thisTopReelValues += " / ";
		}
		
		return thisTopReelValues;
	}
	
	public string DisplayBottomReelValues()
	{
		string thisBottomReelValues = "Bottom Line Values: ";
		
		for (int thisCounter = 0; thisCounter < AllReels.Count; thisCounter++)
		{
			thisBottomReelValues += AllReels[thisCounter].GetBottomReelItemName() + " [" + AllReels[thisCounter].GetBottomReelItemValue() + "]";
			
			if (AllReels.Count - 1 > thisCounter)
				thisBottomReelValues += " / ";
		}
		
		return thisBottomReelValues;
	}

	void SetReelIncrements()
	{
		for (int thisCounter = 0; thisCounter < AllReels.Count; thisCounter++)
			AllReels[thisCounter].ReelIncrements = 360f / AllReels[thisCounter].ReelItems.Count;

	}
}