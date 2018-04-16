using UnityEngine;

public class SmokeStarter : MonoBehaviour
{
	public GameObject smoke;

	void OnEnable()
	{
		smoke.SetActive (true);
	}

	void OnDisable()
	{
		smoke.SetActive (false);
	}
}