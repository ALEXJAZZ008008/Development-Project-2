using UnityEngine;
using UnityEngine.UI;

public class UpdateMetricsText : MonoBehaviour
{
    public Text scoreText;
    public Text timerText;

    // Update is called once per frame
    void Update()
    {
        Scenarios.m_Time += Time.deltaTime;

        scoreText.text = "Score: " + Scenarios.m_Score.ToString();

        timerText.text = "Time: " + ((int)Scenarios.m_Time).ToString();
    }
}