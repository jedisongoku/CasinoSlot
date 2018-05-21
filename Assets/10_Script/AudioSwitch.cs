using UnityEngine;
using System.Collections;

public class AudioSwitch : MonoBehaviour 
{
	public void SwitchAudio()
	{
		if(AudioListener.pause)
		{
			AudioListener.pause = false;
		}
		else 
		{
			AudioListener.pause = true;
		}
	}
}
