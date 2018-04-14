using API;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CameraControler : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject fireCanvas;

    public Text instructionText1;
    public Text instructionText2;

    public Vector3 speed;

    private List<float> fireArc;

    private Vector3 rotation;

    void Awake()
    {
        instructionText1.text = "Press Q to save and quit, press E to reset";

        instructionText2.text = "Select left point with F";

        fireArc = new List<float>();

        rotation = new Vector3();
    }

    private void UpdateCamera()
    {
        rotation.x += speed.x * -Input.GetAxis("Vertical");
        rotation.y -= speed.y * -Input.GetAxis("Horizontal");

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
        if (Input.GetKeyDown(KeyCode.F))
        {
            switch ((fireArc.Count + 2) % 4)
            {
                case 1:

                    fireArc.Add(mainCamera.transform.rotation.eulerAngles.x);

                    if (fireCanvas.activeSelf)
                    {
                        fireCanvas.SetActive(false);
                    }

                    FireArc.m_FireArc = fireArc;

                    fireCanvas.SetActive(true);

                    instructionText2.text = "Select left point with F";

                    break;

                case 2:

                    fireArc.Add(mainCamera.transform.rotation.eulerAngles.y);

                    instructionText2.text = "Select right point with F";

                    break;

                case 3:

                    fireArc.Add(mainCamera.transform.rotation.eulerAngles.y);

                    instructionText2.text = "Select top point with F";

                    break;

                case 0:

                    fireArc.Add(mainCamera.transform.rotation.eulerAngles.x);

                    instructionText2.text = "Select bottom point with F";

                    break;
            }

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (fireCanvas.activeSelf)
            {
                fireCanvas.SetActive(false);
            }

            fireArc.Clear();

            FireArc.m_FireArc = fireArc;

            fireCanvas.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            string output = string.Empty;

            JSONParser.TObjectToJSON(ref output, fireArc);

            using (StreamWriter streamWriter = new StreamWriter(FireArc.m_UniqueOuputPath, true))
            {
                streamWriter.WriteLine(output);
            }

            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        UpdateCamera();
    }
}