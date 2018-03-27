using UnityEngine;

public class OutTransition : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject[] textObjects;
    public GameObject inTransition;
    public float speed;

    private Material material;

	// Use this for initialization
	void Start()
    {
        material = GetComponent<Renderer>().material;
	}

    private void OnEnable()
    {
        for (int i = 0; i < textObjects.Length; i++)
        {
            if (textObjects[i].activeSelf)
            {
                textObjects[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Color colour = material.color;

        if (colour.a < 1.0f)
        {
            colour.a += speed * Time.deltaTime;

            material.color = colour;

            if(colour.a >= 1.0f)
            {
                for(int i = 0; i < objects.Length; i++)
                {
                    if (objects[i].activeSelf)
                    {
                        objects[i].SetActive(false);
                    }
                }
            }
        }
	}

    void OnDisable()
    {
        Color colour = material.color;

        colour.a = 0.0f;

        material.color = colour;

        inTransition.SetActive(true);
    }
}