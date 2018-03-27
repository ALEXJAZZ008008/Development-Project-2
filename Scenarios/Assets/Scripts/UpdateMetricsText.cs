using UnityEngine;
using UnityEngine.UI;

public class UpdateMetricsText : MonoBehaviour
{
    public Text scoreText;
    public Text timerText;

    // Update is called once per frame
    void Update()
    {
        Global.m_Time += Time.deltaTime;

        scoreText.text = "Score: " + Global.m_Score.ToString();

        timerText.text = "Time: " + ((int)Global.m_Time).ToString();
    }
}