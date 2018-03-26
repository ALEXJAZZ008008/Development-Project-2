using UnityEngine;

public class TransitionController : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}