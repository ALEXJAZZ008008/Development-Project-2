using UnityEngine;

public class EmergencyLight : MonoBehaviour
{
    public float speed;
    public float intensity;

    private Material material;
    private bool alphaAscending;

    // Use this for initialization
    void Start()
    {
        material = GetComponent<Renderer>().material;

        alphaAscending = true;
    }

    // Update is called once per frame
    void Update()
    {
        Color colour = material.color;

        float alphaIncrement = speed * Time.deltaTime;

        if (alphaAscending)
        {
            colour.a += alphaIncrement;
        }
        else
        {
            colour.a -= alphaIncrement;
        }

        if (colour.a < 0.0f || colour.a > intensity)
        {
            alphaAscending = !alphaAscending;
        }
        else
        {
            material.color = colour;
        }
    }

    void OnDisable()
    {
        Color colour = material.color;

        colour.a = 0.0f;

        material.color = colour;
    }
}