using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class AudioVisual : MonoBehaviour
{
    public GameObject video;
    public GameObject fireExtinguisherCanvas;
    public GameObject crosshair;
    public GameObject choiceCanvas;
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
        WWW www = new WWW(Scenarios.m_AmbientSoundPath);

        yield return www;

        ambientSoundSource.clip = www.GetAudioClip(false, false);

        ambientSoundSource.Play();
    }

    IEnumerator LoadNarrationCoroutine()
    {
        WWW www = new WWW(Scenarios.m_NarrationPath);

        yield return www;

        narrationSource.clip = www.GetAudioClip(false, false);

        narrationSource.Play();
    }

    IEnumerator LoadSoundEffectCoroutine()
    {
        WWW www = new WWW(Scenarios.m_SoundEffectPath);

        yield return www;

        Scenarios.m_SoundEffectWWWBool = true;

        soundEffectSource.clip = www.GetAudioClip(false, false);
    }

    private void OnEnable()
    {
        videoPlayer.targetTexture.Release();

        if (Scenarios.m_VideoPath != string.Empty)
        {
            videoPlayer.url = Scenarios.m_VideoPath;

            videoPlayer.Prepare();
        }
        else
        {
            Scenarios.m_NextScenario = 0;
            Scenarios.m_UpdateScenario = true;
        }

        if (Scenarios.m_AmbientSoundPath != string.Empty)
        {
            StartCoroutine(LoadAmbientSoundCoroutine());
        }
        else
        {
            ambientSoundSource.Stop();
        }

        if (Scenarios.m_NarrationPath != string.Empty)
        {
            StartCoroutine(LoadNarrationCoroutine());
        }
        else
        {
            narrationSource.Stop();
        }

        if (Scenarios.m_SoundEffectPath != string.Empty)
        {
            StartCoroutine(LoadSoundEffectCoroutine());
        }
        else
        {
            soundEffectSource.Stop();
        }

        ambientSoundSource.volume = Scenarios.m_AmbientSoundVolume;
        narrationSource.volume = Scenarios.m_NarrationVolume;
        soundEffectSource.volume = Scenarios.m_SoundEffectVolume;
        fireSoundEffectSource.volume = Scenarios.m_SoundEffectVolume;
        fireExtinguisherSoundEffectSource.volume = Scenarios.m_SoundEffectVolume;
    }

    void StartChoices(VideoPlayer temporaryVideoPlayer)
    {
        if (fireExtinguisherCanvas.activeSelf)
        {
            fireExtinguisherCanvas.SetActive(false);
        }

        crosshair.SetActive(true);
        choiceCanvas.SetActive(true);
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