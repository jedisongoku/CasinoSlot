using UnityEngine;
using System.Collections;

public class DeactivateItself : MonoBehaviour {

	public float time = 2.0f;

	void OnEnable()
	{
		StartCoroutine ("Deactivate");
	}

	IEnumerator Deactivate()
	{
		yield return new WaitForSeconds (time);

		gameObject.SetActive (false);
	}
}
