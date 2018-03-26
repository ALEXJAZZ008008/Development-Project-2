using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public GameObject[] children;
    public Vector3 speed;

    private Vector3 rotation;

    // Use this for initialization
    void Start()
    {
        rotation = new Vector3();
    }

    private void UpdateChildOnKeyPress(GameObject child, KeyCode keyDown)
    {
        if (Input.GetKeyDown(keyDown))
        {
            child.SetActive(!child.activeSelf);
        }
    }

    private void UpdateCamera()
    {
        rotation.x += speed.x * -Input.GetAxis("Vertical");
        rotation.y -= speed.y * -Input.GetAxis("Horizontal");

        if (rotation.x < -60.0f)
        {
            rotation.x = -60.0f;
        }
        else
        {
            if (rotation.x > 90.0f)
            {
                rotation.x = 90.0f;
            }
        }

        if (rotation.y < 0.0f)
        {
            rotation.y = 360.0f + rotation.y;
        }
        else
        {
            if (rotation.y > 360.0f)
            {
                rotation.y = 0.0f + (rotation.y - 360.0f);
            }
        }

        transform.eulerAngles = new Vector3(rotation.x, rotation.y, rotation.z);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateChildOnKeyPress(children[0], KeyCode.Y);
        UpdateChildOnKeyPress(children[1], KeyCode.U);
        UpdateChildOnKeyPress(children[2], KeyCode.I);
        UpdateChildOnKeyPress(children[3], KeyCode.O);
        UpdateChildOnKeyPress(children[4], KeyCode.P);

        UpdateCamera();
    }
}