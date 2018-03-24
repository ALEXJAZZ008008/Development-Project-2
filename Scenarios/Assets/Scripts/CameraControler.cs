using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public Vector3 speed;

    private Vector3 rotation;

    // Use this for initialization
    void Start()
    {
        rotation = new Vector3();
    }

    // LastUpdate is called once per frame
    void Update()
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
}