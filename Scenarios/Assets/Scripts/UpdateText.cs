using UnityEngine;
using UnityEngine.UI;

public class UpdateText : MonoBehaviour
{
    public Text scenarioText;
    public Text scenarioChoiceText;

    private void UpdateScenarioText(string text)
    {
        scenarioText.text = text;
    }

    private void UpdateScenarioChoiceText(string text)
    {
        scenarioChoiceText.text = text;
    }

    private void UpdateTexts(string temporaryScenarioText, string temporaryScenarioChoiceText)
    {
        UpdateScenarioText(temporaryScenarioText);

        UpdateScenarioChoiceText(temporaryScenarioChoiceText);
    }

    // Use this for initialization
    void Start()
    {
        UpdateTexts("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
    }
}