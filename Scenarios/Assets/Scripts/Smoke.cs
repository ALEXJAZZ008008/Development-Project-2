using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    public GameObject smokePrefab;
    public GameObject oculusCamera;

    public float initialHeight;
    public int smokeIntensity;
    public Vector2 smokeAngles;

    private List<GameObject> smokeList;

    void Awake()
    {
        smokeList = new List<GameObject>();
    }

    void OnEnable()
    {
        float angle = 360 / smokeIntensity;

        float currentAngle = smokeAngles.x;

        for (int i = 0; i < smokeIntensity; i++)
        {
            if (currentAngle <= smokeAngles.y)
            {
                smokeList.Add(Instantiate(smokePrefab));
                smokeList[i].transform.parent = transform;

                smokeList[i].transform.RotateAround(Vector3.zero, oculusCamera.transform.forward, oculusCamera.transform.rotation.eulerAngles.z);
                smokeList[i].transform.RotateAround(Vector3.zero, oculusCamera.transform.right, oculusCamera.transform.rotation.eulerAngles.x + initialHeight);
                smokeList[i].transform.RotateAround(Vector3.zero, oculusCamera.transform.up, oculusCamera.transform.rotation.eulerAngles.y + currentAngle);

                currentAngle += angle;
            }
        }
    }

    void OnDisable()
    {
        for (int i = 0; i < smokeList.Count; i++)
        {
            Destroy(smokeList[i]);
        }

        smokeList.Clear();
    }
}