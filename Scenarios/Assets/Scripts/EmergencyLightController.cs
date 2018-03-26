using UnityEngine;

public class EmergencyLightController : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
	}
}