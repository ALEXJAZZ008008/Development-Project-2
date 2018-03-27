using UnityEngine;
using UnityEngine.UI;

public class Global : MonoBehaviour
{
    public static bool m_UpdateScenario;
    public static int m_CurrentScenario;

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

    public Text scenarioText;
    public Text scenarioChoiceText;

    private void DefaultScenario()
    {
        string loremIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        
        m_VideoPath = Application.dataPath + "/Videos/Stationary1.mp4";
        m_AmbientSoundPath = Application.dataPath + "/Audio/AmbientHospital.wav";
        m_NarrationPath = Application.dataPath + "/Audio/Narration.wav";
        m_SoundEffectPath = Application.dataPath + "/Audio/AlarmSound.wav";
        m_ScenarioText = "Scenario Text: " + loremIpsum;
        m_ScenarioChoiceText = "Scenario Choice Text: " + loremIpsum;

        m_LightingIntensity = 0.25f;
        m_AmbientSoundVolume = 1.0f;
        m_NarrationVolume = 1.0f;
        m_SoundEffectVolume = 1.0f;

        m_SmokeBool = true;
        m_FireBool = true;
        m_FireExtinguisherBool = false;
    }

    private void DefaultScenarios()
    {
        
    }

    void Awake()
    {
        m_UpdateScenario = true;
        m_CurrentScenario = 0;

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

        DefaultScenario();
        DefaultScenarios();
    }

    // Update is called once per frame
    void Update()
    {
        if (scenarioText.text != m_ScenarioText)
        {
            scenarioText.text = m_ScenarioText;
        }

        if (scenarioChoiceText.text != m_ScenarioChoiceText)
        {
            scenarioChoiceText.text = m_ScenarioChoiceText;
        }

        if(m_UpdateScenario)
        {
            smokeCanvas.SetActive(m_SmokeBool);
            fireCanvas.SetActive(m_FireBool);
            fireExtinguisherCanvas.SetActive(m_FireExtinguisherBool);

            m_UpdateScenario = false;
        }
    }
}