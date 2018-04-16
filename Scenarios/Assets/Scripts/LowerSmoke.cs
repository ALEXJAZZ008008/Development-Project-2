using UnityEngine;

public class LowerSmoke : MonoBehaviour
{	
	// Update is called once per frame
	void Update()
	{
		transform.position -= new Vector3(0.0f, 0.005f, 0.0f);
	}
}