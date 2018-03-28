using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class AudioVisual : MonoBehaviour
{
    public GameObject video;
    public GameObject fireExtinguisherCanvas;
    public GameObject scenarioChoiceText;
    public GameObject ambientSound;
    public GameObject narration;
    public GameObject soundEffect;
    public GameObject fireSoundEffect;
    public GameObject fireExtinguisherSoundEffect;

    private VideoPlayer videoPlayer;
    private AudioSource ambientSoundSource;
    private AudioSource narrationSource;
    private AudioSource soundEffectSource;
    private AudioSource fireSoundEffectSource;
    private AudioSource fireExtinguisherSoundEffectSource;

    void Awake()
    {
        videoPlayer = video.GetComponent<VideoPlayer>();

        ambientSoundSource = ambientSound.GetComponent<AudioSource>();
        narrationSource = narration.GetComponent<AudioSource>();
        soundEffectSource = soundEffect.GetComponent<AudioSource>();
        fireSoundEffectSource = fireSoundEffect.GetComponent<AudioSource>();
        fireExtinguisherSoundEffectSource = fireExtinguisherSoundEffect.GetComponent<AudioSource>();
    }

    IEnumerator LoadAmbientSoundCoroutine()
    {
        WWW www = new WWW(Global.m_AmbientSoundPath);

        yield return www;

        ambientSoundSource.clip = www.GetAudioClip(false, false);

        ambientSoundSource.Play();
    }

    IEnumerator LoadNarrationCoroutine()
    {
        WWW www = new WWW(Global.m_NarrationPath);

        yield return www;

        narrationSource.clip = www.GetAudioClip(false, false);

        narrationSource.Play();
    }

    IEnumerator LoadSoundEffectCoroutine()
    {
        WWW www = new WWW(Global.m_SoundEffectPath);

        yield return www;

        soundEffectSource.clip = www.GetAudioClip(false, false);
    }

    private void OnEnable()
    {
        videoPlayer.targetTexture.Release();

        videoPlayer.url = Global.m_VideoPath;

        videoPlayer.Prepare();

        StartCoroutine(LoadAmbientSoundCoroutine());
        StartCoroutine(LoadNarrationCoroutine());
        StartCoroutine(LoadSoundEffectCoroutine());

        ambientSoundSource.volume = Global.m_AmbientSoundVolume;
        narrationSource.volume = Global.m_NarrationVolume;
        soundEffectSource.volume = Global.m_SoundEffectVolume;
        fireSoundEffectSource.volume = Global.m_SoundEffectVolume;
        fireExtinguisherSoundEffectSource.volume = Global.m_SoundEffectVolume;
    }

    void StartChoices(VideoPlayer temporaryVideoPlayer)
    {
        if (fireExtinguisherCanvas.activeSelf)
        {
            fireExtinguisherCanvas.SetActive(false);
        }

        scenarioChoiceText.SetActive(true);

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

        ambientSoundSource.Stop();

        if (narrationSource.isPlaying)
        {
            narrationSource.Stop();
        }
    }
}