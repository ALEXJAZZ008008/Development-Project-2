using System.Collections;
using System.Collections.Generic;
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
	
	// Update is called once per frame
	void Update()
    {
		
	}
}
