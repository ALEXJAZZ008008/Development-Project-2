using UnityEngine;
using UnityEngine.Video;

public class VideoSelector : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    // Use this for initialization
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        videoPlayer.Play();
    }

    private void OnDestroy()
    {
        //videoPlayer.Stop();
    }
}
