// --------------ABOUT AND COPYRIGHT----------------------
//  Copyright © 2013 SketchWork Productions Limited
//        support@sketchworkproductions.com
// -------------------------------------------------------

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class SWP_InternalSlotReel
{
	public string ReelName;
	public GameObject ReelRoot;
	public bool IsExpanded; 
	public List<SWP_InternalSlotReelItem> ReelItems;
	internal int CurrentReelValue; 
	public int FixedReelValue; 
	public float ReelRotation;
	public float ReelIncrements;
	public bool ReelHeld = false;
	
	public int GetTopReelItemValue()
	{
		if (CurrentReelValue != -1)   
		{
			if (CurrentReelValue == 0)
				return ReelItems[ReelItems.Count - 1].ReelValue;
			else
				return ReelItems[CurrentReelValue - 1].ReelValue;
		}
		else
			return -1;
	}
	
	public string GetTopReelItemName()
	{
		if (CurrentReelValue != -1) 
		{
			if (CurrentReelValue == 0)
				return ReelItems[ReelItems.Count - 1].ReelItemName;
			else
				return ReelItems[CurrentReelValue - 1].ReelItemName;
		}
		else
			return "Not Assigned";
	}
	
	public int GetBottomReelItemValue()
	{
		if (CurrentReelValue != -1) 
		{
			if (CurrentReelValue == ReelItems.Count - 1)
				return ReelItems[0].ReelValue;
			else
				return ReelItems[CurrentReelValue + 1].ReelValue;
		}
		else
			return -1;
	}
	
	public string GetBottomReelItemName()
	{
		if (CurrentReelValue != -1) 
		{
			if (CurrentReelValue == ReelItems.Count - 1)
				return ReelItems[0].ReelItemName;
			else
				return ReelItems[CurrentReelValue + 1].ReelItemName;
		}
		else
			return "Not Assigned";
	}
	
	public int GetMiddleReelItemValue()
	{
		if (CurrentReelValue == -1)
			return -1;
		else 
			return ReelItems[CurrentReelValue].ReelValue;
	}
	
	public string GetMiddleReelItemName()
	{
		if (CurrentReelValue == -1)
			return "Not Assigned";
		else 
			return ReelItems[CurrentReelValue].ReelItemName;
	}
}