// --------------ABOUT AND COPYRIGHT----------------------
//  Copyright © 2013 SketchWork Productions Limited
//        support@sketchworkproductions.com
// -------------------------------------------------------

using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class SWP_InternalSlotReelItem
{
	public string ReelItemName;
	public int ReelValue;

	public SWP_InternalSlotReelItem (int _ReelValue)
	{
		ReelItemName = "";
		ReelValue = _ReelValue;
	}
}