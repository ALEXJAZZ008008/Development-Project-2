using System.Collections;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public GameObject ambientSound;
    public GameObject narration;
    public GameObject soundEffect;

    private AudioSource ambientSoundSource;
    private AudioSource narrationSource;
    private AudioSource soundEffectSource;

    void Awake()
    {
        ambientSoundSource = ambientSound.GetComponent<AudioSource>();
        narrationSource = narration.GetComponent<AudioSource>();
        soundEffectSource = soundEffect.GetComponent<AudioSource>();
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

    void OnEnable()
    {
        StartCoroutine(LoadAmbientSoundCoroutine());
        StartCoroutine(LoadNarrationCoroutine());
        StartCoroutine(LoadSoundEffectCoroutine());

        ambientSoundSource.volume = Global.m_AmbientSoundVolume;
        narrationSource.volume = Global.m_NarrationVolume;
        soundEffectSource.volume = Global.m_SoundEffectVolume;
    }

    private void OnDisable()
    {
        if (ambientSoundSource.isPlaying)
        {
            ambientSoundSource.Stop();
        }

        if (narrationSource.isPlaying)
        {
            narrationSource.Stop();
        }
    }
}