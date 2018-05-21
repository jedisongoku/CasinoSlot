using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {
	
	public float timeSinceLevelLoad = 3.0f;//how long we want at least to wait until the game ends
	public string loadScene;// type in the inspector the name of the scene that will be loaded

	void Update () 
	{
		if(Application.GetStreamProgressForLevel(loadScene) == 1 && Time.timeSinceLevelLoad > timeSinceLevelLoad)//when application is ready to load scene called 05_01MissionOctagon and if the time set in inspector has passed
		{
			Application.LoadLevel(loadScene);//application will load scene called 05_01MissionOctagon
		}
	}
}
