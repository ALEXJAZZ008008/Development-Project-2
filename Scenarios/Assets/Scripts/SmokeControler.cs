using UnityEngine;

public class SmokeControler : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}