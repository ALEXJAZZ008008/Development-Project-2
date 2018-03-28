using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject soundEffect;
    public GameObject outTransition;
    public Vector3 speed;

    private AudioSource soundEffectSource;
    private Vector3 rotation;

    void Awake()
    {
        soundEffectSource = soundEffect.GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start()
    {
        rotation = new Vector3();
    }

    private void UpdateObjectActivityOnKeyPress(GameObject child, KeyCode keyDown)
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
        UpdateObjectActivityOnKeyPress(objects[0], KeyCode.T);
        UpdateObjectActivityOnKeyPress(objects[1], KeyCode.Y);
        UpdateObjectActivityOnKeyPress(objects[2], KeyCode.U);
        UpdateObjectActivityOnKeyPress(objects[3], KeyCode.I);

        UpdateObjectActivityOnKeyPress(soundEffect, KeyCode.O);

        if(soundEffect.activeSelf)
        {
            if(!soundEffectSource.isPlaying)
            {
                soundEffectSource.Play();
            }
        }
        else
        {
            if (soundEffectSource.isPlaying)
            {
                soundEffectSource.Stop();
            }
        }

        if (!outTransition.activeSelf)
        {
            UpdateObjectActivityOnKeyPress(outTransition, KeyCode.P);
        }

        UpdateCamera();
    }
}