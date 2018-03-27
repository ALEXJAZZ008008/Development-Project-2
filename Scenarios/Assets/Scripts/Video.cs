using UnityEngine;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    public GameObject scenarioChoiceText;
    public GameObject fireExtinguisherCanvas;

    private VideoPlayer videoPlayer;

    void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    private void OnEnable()
    {
        videoPlayer.url = Global.m_VideoPath;

        videoPlayer.Prepare();
    }

    void StartChoices(VideoPlayer temporaryVideoPlayer)
    {
        scenarioChoiceText.SetActive(true);

        if (fireExtinguisherCanvas.activeSelf)
        {
            fireExtinguisherCanvas.SetActive(false);
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

    private void OnDestroy()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Stop();
        }
    }
}