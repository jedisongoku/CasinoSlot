using UnityEngine;
using System.Collections;

public class DeactivateGameObject : MonoBehaviour 
{
	public GameObject some_object;

	public void Deactivate()
	{
		some_object.SetActive(false);
	}
}
