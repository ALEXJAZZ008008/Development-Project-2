using API;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Global : MonoBehaviour
{
    public static bool m_UpdateScenario;
    public static int m_NextScenario;

    public static List<Choice> m_Choices;

    public static string m_VideoPath;
    public static string m_AmbientSoundPath;
    public static string m_NarrationPath;
    public static string m_SoundEffectPath;
    public static string m_ScenarioText;
    public static string m_ScenarioChoiceText;

    public static float m_LightingIntensity;
    public static float m_AmbientSoundVolume;
    public static float m_NarrationVolume;
    public static float m_SoundEffectVolume;

    public static bool m_SmokeBool;
    public static bool m_FireBool;
    public static bool m_FireExtinguisherBool;

    public static int m_Score;
    public static float m_Time;

    public GameObject smokeCanvas;
    public GameObject fireCanvas;
    public GameObject fireExtinguisherCanvas;

    public TextAsset defaultScenarioListJSON;

    public Text scenarioText;
    public Text scenarioChoiceText;

    public bool inportScenarioBool;
    public bool defaultScenarioListBool;

    private ScenarioList scenarioList;

    private int currentScenario;

    private void DefaultScenario()
    {
        m_VideoPath = Application.dataPath + "/Videos/Stationary1.mp4";
        m_AmbientSoundPath = Application.dataPath + "/Audio/AmbientHospital.wav";
        m_NarrationPath = Application.dataPath + "/Audio/Narration.wav";
        m_SoundEffectPath = Application.dataPath + "/Audio/AlarmSound.wav";
        m_ScenarioText = "scenarioText";
        m_ScenarioChoiceText = "scenarioChoiceText";

        m_LightingIntensity = 0.25f;
        m_AmbientSoundVolume = 0.75f;
        m_NarrationVolume = 1.0f;
        m_SoundEffectVolume = 0.75f;

        m_SmokeBool = false;
        m_FireBool = false;
        m_FireExtinguisherBool = false;
    }

    private void UpdateCurrentScenario()
    {
        m_Choices = scenarioList.GetScenarios()[currentScenario].GetChoices();

        m_VideoPath = scenarioList.GetScenarios()[currentScenario].GetVideoPath();
        m_AmbientSoundPath = scenarioList.GetScenarios()[currentScenario].GetAmbientSoundPath();
        m_NarrationPath = scenarioList.GetScenarios()[currentScenario].GetNarrationPath();
        m_SoundEffectPath = scenarioList.GetScenarios()[currentScenario].GetSoundEffectPath();
        m_ScenarioText = scenarioList.GetScenarios()[currentScenario].GetScenarioText();
        m_ScenarioChoiceText = scenarioList.GetScenarios()[currentScenario].GetScenarioChoiceText();

        m_LightingIntensity = scenarioList.GetScenarios()[currentScenario].GetLightingIntensity();
        m_AmbientSoundVolume = scenarioList.GetScenarios()[currentScenario].GetAmbientSoundVolume();
        m_NarrationVolume = scenarioList.GetScenarios()[currentScenario].GetNarrationVolume();
        m_SoundEffectVolume = scenarioList.GetScenarios()[currentScenario].GetSoundEffectVolume();

        m_SmokeBool = scenarioList.GetScenarios()[currentScenario].GetSmokeBool();
        m_FireBool = scenarioList.GetScenarios()[currentScenario].GetFireBool();
        m_FireExtinguisherBool = scenarioList.GetScenarios()[currentScenario].GetFireExtinguisherBool();
    }

    private void InportScenarioList()
    {
        string[] commandLineArguments = Environment.GetCommandLineArgs();

        if (commandLineArguments.Length < 2 || defaultScenarioListBool)
        {
            JSONParser.JSONToTObject(defaultScenarioListJSON.text, ref scenarioList);
        }
        else
        {
            JSONParser.JSONToTObject(commandLineArguments[1], ref scenarioList);
        }

        UpdateCurrentScenario();
    }

    void Awake()
    {
        m_UpdateScenario = true;
        m_NextScenario = 0;

        m_Choices = new List<Choice>();

        m_VideoPath = string.Empty;
        m_AmbientSoundPath = string.Empty;
        m_NarrationPath = string.Empty;
        m_SoundEffectPath = string.Empty;
        m_ScenarioText = string.Empty;
        m_ScenarioChoiceText = string.Empty;

        m_LightingIntensity = 0.0f;
        m_AmbientSoundVolume = 0.0f;
        m_NarrationVolume = 0.0f;
        m_SoundEffectVolume = 0.0f;

        m_SmokeBool = false;
        m_FireBool = false;
        m_FireExtinguisherBool = false;

        m_Score = 0;
        m_Time = 0.0f;

        currentScenario = 0;

        if (inportScenarioBool)
        {
            InportScenarioList();
        }
        else
        {
            DefaultScenario();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScenario != m_NextScenario)
        {
            currentScenario = m_NextScenario;

            if (currentScenario < 0 || currentScenario >= scenarioList.GetScenarios().Count)
            {
                currentScenario = 0;
                m_NextScenario = 0;
            }

            UpdateCurrentScenario();
        }

        if (m_UpdateScenario)
        {
            smokeCanvas.SetActive(m_SmokeBool);
            fireCanvas.SetActive(m_FireBool);
            fireExtinguisherCanvas.SetActive(m_FireExtinguisherBool);

            m_UpdateScenario = false;
        }

        if (scenarioText.text != m_ScenarioText)
        {
            scenarioText.text = m_ScenarioText;
        }

        if (scenarioChoiceText.text != m_ScenarioChoiceText)
        {
            scenarioChoiceText.text = m_ScenarioChoiceText;
        }
    }
}