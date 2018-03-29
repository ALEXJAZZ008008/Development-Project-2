using UnityEngine;
using UnityEngine.UI;

public class ChoiceTrigger : MonoBehaviour
{
    public string feedbackText;

    public int nextScenarioIndex;
    public int score;

    public GameObject outTransition;

    public Text countdownTextAsset;

    private float timer;

    void Awake()
    {
        timer = 10.0f;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Crosshair"))
        {
            timer -= Time.deltaTime;

            countdownTextAsset.text = ((int)timer).ToString();

            if (timer <= 0.0f)
            {
                Scenarios.m_NextScenario = nextScenarioIndex;

                if(!outTransition.activeSelf)
                {
                    outTransition.SetActive(true);
                }

                Scenarios.m_Score += score;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Crosshair"))
        {
            timer = 10.0f;

            countdownTextAsset.text = ((int)timer).ToString();
        }
    }
}
