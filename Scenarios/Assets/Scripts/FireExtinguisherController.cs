using UnityEngine;

public class FireExtinguisherController : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}