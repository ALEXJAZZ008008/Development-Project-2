using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public GameObject[] objects;
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
        UpdateChildOnKeyPress(objects[0], KeyCode.T);
        UpdateChildOnKeyPress(objects[1], KeyCode.Y);
        UpdateChildOnKeyPress(objects[2], KeyCode.U);
        UpdateChildOnKeyPress(objects[3], KeyCode.I);
        UpdateChildOnKeyPress(objects[4], KeyCode.O);
        UpdateChildOnKeyPress(objects[5], KeyCode.P);

        UpdateCamera();
    }
}