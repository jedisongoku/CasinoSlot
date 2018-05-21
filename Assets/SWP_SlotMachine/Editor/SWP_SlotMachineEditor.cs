// --------------ABOUT AND COPYRIGHT----------------------
//  Copyright © 2013 SketchWork Productions Limited
//        support@sketchworkproductions.com
// -------------------------------------------------------

using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(SWP_SlotMachine))]
public class SWP_SlotMachineEditor : Editor
{
	static public bool ShowHeader = true;
	static public bool ShowTitles = true;
	static public bool ShowQuickDebugControls = true;
	
	public override void OnInspectorGUI()  
	{
		SWP_SlotMachine _SlotMachineScript = (SWP_SlotMachine)target;  
		
		#region GLOBAL STATIC CONTROLS
		if (SWP_SlotMachineEditor.ShowHeader)
			GetHeader();
		
		if (SWP_SlotMachineEditor.ShowTitles)
		{
			EditorGUILayout.BeginHorizontal(EditorStyles.objectFieldThumb);
			EditorGUILayout.LabelField("Slot Machine Globals");
			EditorGUILayout.EndHorizontal();
		}

		#if UNITY_4_3
		EditorGUILayout.BeginVertical(EditorStyles.miniButtonMid);
		SWP_SlotMachineEditor.ShowHeader = EditorGUILayout.ToggleLeft("Show Editor Header", SWP_SlotMachineEditor.ShowHeader);
		SWP_SlotMachineEditor.ShowTitles = EditorGUILayout.ToggleLeft("Show Editor Titles", SWP_SlotMachineEditor.ShowTitles);
		SWP_SlotMachineEditor.ShowQuickDebugControls = EditorGUILayout.ToggleLeft("Show Debug Controls", SWP_SlotMachineEditor.ShowQuickDebugControls);
		#else
		EditorGUILayout.BeginVertical();
		SWP_SlotMachineEditor.ShowHeader = EditorGUILayout.Toggle("Show Editor Header", SWP_SlotMachineEditor.ShowHeader);
		SWP_SlotMachineEditor.ShowTitles = EditorGUILayout.Toggle("Show Editor Titles", SWP_SlotMachineEditor.ShowTitles);
		SWP_SlotMachineEditor.ShowQuickDebugControls = EditorGUILayout.Toggle("Show Debug Controls", SWP_SlotMachineEditor.ShowQuickDebugControls);
		#endif
		EditorGUILayout.EndVertical();
		#endregion

		#region SOUND CONTROLS
		EditorGUILayout.BeginHorizontal(EditorStyles.objectFieldThumb);
		#if UNITY_4_3
		_SlotMachineScript.EnableSound = EditorGUILayout.ToggleLeft("Enable Sound", _SlotMachineScript.EnableSound);
		#else
		_SlotMachineScript.EnableSound = EditorGUILayout.Toggle("Enable Sound", _SlotMachineScript.EnableSound);
		#endif
		EditorGUILayout.EndHorizontal();
		
		if (_SlotMachineScript.EnableSound)
		{
			#if UNITY_4_3
			EditorGUILayout.BeginVertical(EditorStyles.miniButtonMid);
			#else
			EditorGUILayout.BeginVertical();
			#endif
			_SlotMachineScript.SoundVolume = EditorGUILayout.Slider("Sound Volume", _SlotMachineScript.SoundVolume, 0f, 1f);
			_SlotMachineScript.ReelSpinSound = (AudioClip) EditorGUILayout.ObjectField("Spin Audio", _SlotMachineScript.ReelSpinSound, typeof(AudioClip), false);
			_SlotMachineScript.ReelStopSound = (AudioClip) EditorGUILayout.ObjectField("Stop Audio", _SlotMachineScript.ReelStopSound, typeof(AudioClip), false);
			_SlotMachineScript.ReelWinSound = (AudioClip) EditorGUILayout.ObjectField("Win Audio", _SlotMachineScript.ReelWinSound, typeof(AudioClip), false);
			_SlotMachineScript.ReelNudgeUpSound = (AudioClip) EditorGUILayout.ObjectField("Nudge Up Audio", _SlotMachineScript.ReelNudgeUpSound, typeof(AudioClip), false);
			_SlotMachineScript.ReelNudgeDownSound = (AudioClip) EditorGUILayout.ObjectField("Nudge Down Audio", _SlotMachineScript.ReelNudgeDownSound, typeof(AudioClip), false);
			EditorGUILayout.EndVertical();
		}
		#endregion

		#region MAIN SLOT SETTINGS
		if (SWP_SlotMachineEditor.ShowTitles)  
		{
			EditorGUILayout.BeginHorizontal(EditorStyles.objectFieldThumb);
			EditorGUILayout.LabelField("Slot Machine Controls (Reels = " + _SlotMachineScript.AllReels.Count.ToString() + ")");
			EditorGUILayout.EndHorizontal();
		}

		#if UNITY_4_3
		EditorGUILayout.BeginVertical(EditorStyles.miniButtonMid);
		#else
		EditorGUILayout.BeginVertical();
		#endif
		_SlotMachineScript.PreSpinDuration = EditorGUILayout.Slider("Pre-Spin (Seconds)", _SlotMachineScript.PreSpinDuration, 1f, 10f);
		_SlotMachineScript.SpeedModifier = EditorGUILayout.FloatField("Spin Speed Modifier", _SlotMachineScript.SpeedModifier);

		#if UNITY_4_3
		_SlotMachineScript.EnableMiddleLineWin = EditorGUILayout.ToggleLeft("Enable Main Line Win", _SlotMachineScript.EnableMiddleLineWin);
		_SlotMachineScript.EnableTopLineWin = EditorGUILayout.ToggleLeft("Enable Top Line Win", _SlotMachineScript.EnableTopLineWin);
		_SlotMachineScript.EnableBottomLineWin = EditorGUILayout.ToggleLeft("Enable Bottom Line Win", _SlotMachineScript.EnableBottomLineWin);
		#else
		_SlotMachineScript.EnableMiddleLineWin = EditorGUILayout.Toggle("Enable Main Line Win", _SlotMachineScript.EnableMiddleLineWin);
		_SlotMachineScript.EnableTopLineWin = EditorGUILayout.Toggle("Enable Top Line Win", _SlotMachineScript.EnableTopLineWin);
		_SlotMachineScript.EnableBottomLineWin = EditorGUILayout.Toggle("Enable Bottom Line Win", _SlotMachineScript.EnableBottomLineWin);
		#endif

		if (_SlotMachineScript.AllReels.Count > 0)
		{
			#if UNITY_4_3
			_SlotMachineScript.EnableFixSpin = EditorGUILayout.ToggleLeft("Fix The Reels", _SlotMachineScript.EnableFixSpin);
			#else
			_SlotMachineScript.EnableFixSpin = EditorGUILayout.Toggle("Fix The Reels", _SlotMachineScript.EnableFixSpin);
			#endif
		}

		if (GUILayout.Button("Add New Reel") && Application.isEditor)
			AddNewReel(_SlotMachineScript);

		for (int thisCounter = 0; thisCounter < _SlotMachineScript.AllReels.Count; thisCounter++)
		{
			GetReelLine(_SlotMachineScript, thisCounter);

			GetReelItemLines(_SlotMachineScript, thisCounter);
		}

		EditorGUILayout.EndVertical();	
		#endregion

		#region DEBUG SECTION CONTROLS
		if (SWP_SlotMachineEditor.ShowQuickDebugControls)
		{ 
			if (SWP_SlotMachineEditor.ShowTitles)  
			{
				EditorGUILayout.BeginHorizontal(EditorStyles.objectFieldThumb);
				EditorGUILayout.LabelField("Quick Debug Controls");
				EditorGUILayout.EndHorizontal();
			}
			
			#if UNITY_4_3
			EditorGUILayout.BeginVertical(EditorStyles.miniButtonMid);
			#else
			EditorGUILayout.BeginVertical();
			#endif   
			EditorGUILayout.BeginHorizontal();
			
			if (GUILayout.Button("Auto Start / Stop") && Application.isPlaying)
				_SlotMachineScript.StartStopReels();
			
			EditorGUILayout.EndHorizontal();		
			EditorGUILayout.BeginHorizontal(); 
			
			if (GUILayout.Button("Start Reels") && Application.isPlaying)
				_SlotMachineScript.StartReels();
			
			if (GUILayout.Button("Stop Reels") && Application.isPlaying)
				_SlotMachineScript.StopReels();
			
			EditorGUILayout.EndHorizontal();		

			if (_SlotMachineScript.AllReels.Count > 0)
			{
				if (SWP_SlotMachineEditor.ShowTitles)    
				{
					EditorGUILayout.BeginHorizontal(EditorStyles.objectFieldThumb);
					EditorGUILayout.LabelField("Quick Nudges");
					EditorGUILayout.EndHorizontal();
				}

				EditorGUILayout.BeginHorizontal();
				
				for (int thisCounter = 0; thisCounter < _SlotMachineScript.AllReels.Count; thisCounter++)
					if (GUILayout.Button(thisCounter.ToString("00") + "U") && Application.isPlaying)
						_SlotMachineScript.NudgeReels(true, thisCounter);
				
				EditorGUILayout.EndHorizontal();		
				EditorGUILayout.BeginHorizontal();
				
				for (int thisCounter = 0; thisCounter < _SlotMachineScript.AllReels.Count; thisCounter++)
					if (GUILayout.Button(thisCounter.ToString("00") + "D") && Application.isPlaying)
						_SlotMachineScript.NudgeReels(false, thisCounter);
				
				EditorGUILayout.EndHorizontal();		
			}

			EditorGUILayout.EndVertical();	
		}
		#endregion

		if (GUI.changed)
			EditorUtility.SetDirty(_SlotMachineScript);

		this.Repaint();
	}

	void GetReelLine(SWP_SlotMachine _SlotMachine, int _ReelNumber)
	{
		EditorGUILayout.BeginHorizontal(EditorStyles.objectFieldThumb);

		EditorGUILayout.LabelField("Reel " + (_ReelNumber).ToString(), GUILayout.Width(65)); 
		_SlotMachine.AllReels[_ReelNumber].ReelRoot = (GameObject) EditorGUILayout.ObjectField("", _SlotMachine.AllReels[_ReelNumber].ReelRoot, typeof(GameObject), true);
		
		if (_SlotMachine.EnableFixSpin)
			_SlotMachine.AllReels[_ReelNumber].FixedReelValue = EditorGUILayout.IntField(_SlotMachine.AllReels[_ReelNumber].FixedReelValue, GUILayout.Width(50));
		
		if (_SlotMachine.AllReels[_ReelNumber].ReelHeld && GUILayout.Button("H", GUILayout.Width(25)) && Application.isEditor)
			_SlotMachine.AllReels[_ReelNumber].ReelHeld = !_SlotMachine.AllReels[_ReelNumber].ReelHeld;
		else if (!_SlotMachine.AllReels[_ReelNumber].ReelHeld && GUILayout.Button("-", GUILayout.Width(25)) && Application.isEditor)
			_SlotMachine.AllReels[_ReelNumber].ReelHeld = !_SlotMachine.AllReels[_ReelNumber].ReelHeld;


		if (GUILayout.Button("X", GUILayout.Width(25)) && Application.isEditor)
			RemoveReel(_SlotMachine, _ReelNumber);
		
		if (GUILayout.Button("+", GUILayout.Width(25)) && Application.isEditor)
			AddReelItem(_SlotMachine, _ReelNumber);

		EditorGUILayout.EndHorizontal();
	}  
	
	void GetReelItemLines(SWP_SlotMachine _SlotMachine, int _ReelNumber)
	{
		EditorGUI.indentLevel = 1;

		_SlotMachine.AllReels[_ReelNumber].IsExpanded = EditorGUILayout.Foldout(_SlotMachine.AllReels[_ReelNumber].IsExpanded, "Reel " + (_ReelNumber).ToString() + " Items");

		if (_SlotMachine.AllReels[_ReelNumber].IsExpanded)
		{
			EditorGUI.indentLevel = 2;

			for (int thisCounter = 0; thisCounter < _SlotMachine.AllReels[_ReelNumber].ReelItems.Count; thisCounter++)
			{
				EditorGUILayout.BeginHorizontal();

				EditorGUILayout.LabelField("I " + (thisCounter).ToString(), GUILayout.Width(50)); 
				_SlotMachine.AllReels[_ReelNumber].ReelItems[thisCounter].ReelItemName = EditorGUILayout.TextField("", _SlotMachine.AllReels[_ReelNumber].ReelItems[thisCounter].ReelItemName, GUILayout.MinWidth(80)); 
				_SlotMachine.AllReels[_ReelNumber].ReelItems[thisCounter].ReelValue = EditorGUILayout.IntField(_SlotMachine.AllReels[_ReelNumber].ReelItems[thisCounter].ReelValue, GUILayout.Width(70));

				if (GUILayout.Button("X", GUILayout.Width(25)) && Application.isEditor)
					RemoveReelItem(_SlotMachine, _ReelNumber, thisCounter);

				EditorGUILayout.EndHorizontal();
			}
		}

		EditorGUI.indentLevel = 0;
	}
	
	void AddNewReel(SWP_SlotMachine _SlotMachine)
	{
		SWP_InternalSlotReel thisReel = new SWP_InternalSlotReel();
		_SlotMachine.AllReels.Add(thisReel);
	}

	void RemoveReel(SWP_SlotMachine _SlotMachine, int _IndexToDelete)
	{
		_SlotMachine.AllReels.RemoveAt(_IndexToDelete);
	}
	
	void AddReelItem(SWP_SlotMachine _SlotMachine, int _ReelNumber)
	{
		SWP_InternalSlotReelItem thisReelItem = new SWP_InternalSlotReelItem(_SlotMachine.AllReels[_ReelNumber].ReelItems.Count + 1);
		_SlotMachine.AllReels[_ReelNumber].ReelItems.Add(thisReelItem);
	}
	
	void RemoveReelItem(SWP_SlotMachine _SlotMachine, int _ReelNumber, int _IndexToDelete)
	{
		_SlotMachine.AllReels[_ReelNumber].ReelItems.RemoveAt(_IndexToDelete);
	}

	void GetHeader()
	{
		Texture thisTextureHeader = (Texture) AssetDatabase.LoadAssetAtPath("Assets/SWP_SlotMachine/Editor/Textures/SketchWorkHeader.png", typeof(Texture));
		
		if (thisTextureHeader != null)
		{
			Rect thisRect = GUILayoutUtility.GetRect(0f, 0f);
			thisRect.width = thisTextureHeader.width;
			thisRect.height = thisTextureHeader.height;
			GUILayout.Space(thisRect.height);
			GUI.DrawTexture(thisRect, thisTextureHeader);
		}
	}
}
