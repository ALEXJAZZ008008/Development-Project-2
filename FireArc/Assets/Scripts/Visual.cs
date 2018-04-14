using UnityEngine;
using UnityEngine.Video;

public class Visual : MonoBehaviour
{
    public GameObject video;
    public GameObject crosshair;

    private VideoPlayer videoPlayer;

    void Awake()
    {
        videoPlayer = video.GetComponent<VideoPlayer>();
    }

    private void OnEnable()
    {
        videoPlayer.targetTexture.Release();

        if (FireArc.m_VideoPath != string.Empty)
        {
            videoPlayer.url = FireArc.m_VideoPath;

            videoPlayer.Prepare();
        }
        else
        {
            Application.Quit();
        }
    }

    void StartChoices(VideoPlayer temporaryVideoPlayer)
    {
        if (FireArc.m_Choices.Count > 1)
        {
            crosshair.SetActive(true);
        }
        else
        {
            if (FireArc.m_Choices.Count == 1)
            {
                FireArc.m_NextScenario = FireArc.m_Choices[0].GetNextScenarioIndex();
            }
            else
            {
                Application.Quit();
            }
        }

        videoPlayer.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.isPrepared && !videoPlayer.isPlaying)
        {
            videoPlayer.Play();
        }

        videoPlayer.loopPointReached += StartChoices;
    }

    private void OnDisable()
    {
        videoPlayer.Stop();
    }
}