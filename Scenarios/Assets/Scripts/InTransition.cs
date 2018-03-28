﻿using UnityEngine;

public class InTransition : MonoBehaviour
{
    public GameObject outTransition;
    public GameObject audioVisual;
    public GameObject scenarioText;
    public GameObject metricsText;
    public float pauseLength;
    public float speed;

    private Material material;
    private float pause;

    void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    void OnEnable()
    {
        if (outTransition.activeSelf)
        {
            gameObject.SetActive(false);
        }

        Global.m_UpdateScenario = true;

        scenarioText.SetActive(true);

        pause = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (pause <= pauseLength)
        {
            if (!Global.m_UpdateScenario && !audioVisual.activeSelf)
            {
                audioVisual.SetActive(true);
            }

            pause += 1.0f * Time.deltaTime;
        }
        else
        {
            if (scenarioText.activeSelf)
            {
                scenarioText.SetActive(false);
            }

            Color colour = material.color;

            if (colour.a > 0.0f)
            {
                colour.a -= speed * Time.deltaTime;

                material.color = colour;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

    void OnDisable()
    {
        Color colour = material.color;

        colour.a = 1.0f;

        material.color = colour;

        metricsText.SetActive(true);
    }
}