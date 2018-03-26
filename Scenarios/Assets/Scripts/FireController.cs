using UnityEngine;

public class FireController : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}