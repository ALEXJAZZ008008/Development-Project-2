using UnityEngine;
using UnityEngine.UI;

public class UpdateMetricsText : MonoBehaviour
{
    public Text scoreText;
    public Text timerText;

    private float time;
    private int score;

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void UpdateTimerText()
    {
        timerText.text = "Time: " + ((int)time).ToString();
    }

    private void UpdateMetrics()
    {
        UpdateScoreText();

        UpdateTimerText();
    }

    // Use this for initialization
    void Start()
    {
        time = 0.0f;
        score = 0;

        UpdateMetrics();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        UpdateMetrics();
    }
}