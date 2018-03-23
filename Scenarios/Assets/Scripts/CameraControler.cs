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

        transform.eulerAngles = new Vector3(rotation.x, rotation.y, rotation.z);
    }
}