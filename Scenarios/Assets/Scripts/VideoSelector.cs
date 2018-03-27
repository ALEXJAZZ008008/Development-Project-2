using UnityEngine;
using UnityEngine.Video;

public class VideoSelector : MonoBehaviour
{
    public GameObject scenarioChoiceText;
    public GameObject fireExtinguisherCanvas;

    private VideoPlayer videoPlayer;

    // Use this for initialization
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        videoPlayer.Play();
    }

    void StartChoices(VideoPlayer temporaryVideoPlayer)
    {
        scenarioChoiceText.SetActive(true);

        if(fireExtinguisherCanvas.activeSelf)
        {
            fireExtinguisherCanvas.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        videoPlayer.loopPointReached += StartChoices;
    }

    private void OnDestroy()
    {
        videoPlayer.Stop();
    }
}