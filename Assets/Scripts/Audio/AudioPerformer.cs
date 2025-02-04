using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

/*
 * Este script busca todos los Audio players (scriptable objects) dentro de una carpeta y genera un audio source (que permite reproducir el sonido)
 * por cada uno de estos.
*/
public class AudioPerformer : MonoBehaviour
{
    [SerializeField]
    float _timeToWait = 0.01f;

    AudioPlayer[] _audioPlayer;
    static private AudioPerformer _instance;
    private void Awake()
    {

        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
            _audioPlayer = Resources.LoadAll<AudioPlayer>("SoundPlayers");

            for (int i = 0; i < _audioPlayer.Length; i++)
            {
                AudioSource currentSource = gameObject.AddComponent<AudioSource>();

                _audioPlayer[i].OnLoadMusic.
                AddListener((AudioClip clip, (float volume, float pitch) volume_pitch, bool loop) =>
                {
                    SetValues(currentSource, clip, volume_pitch, loop);
                }
                );

                _audioPlayer[i].OnMusicPlay.
                AddListener((AudioClip clip, (float volume, float pitch) volume_pitch, float fadeInTime, bool loop) =>
                {
                    SetValues(currentSource, clip, volume_pitch, loop);

                    currentSource.Play();
                    //StartCoroutine(FadeIn(fadeInTime, currentSource, volume_pitch.volume));
                }
                );

                _audioPlayer[i].OnAudioPlay.
                AddListener((AudioClip clip, (float volume, float pitch) volume_pitch, float fadeInTime, bool loop) =>
                {
                    SetValues(currentSource, clip, volume_pitch, loop);
                    currentSource.PlayOneShot(clip);
                    //StartCoroutine(FadeIn(fadeInTime, currentSource, volume_pitch.volume));
                }
                );

                _audioPlayer[i].OnAudioStop.AddListener((float fadeOutTime) => 
                {
                    //StartCoroutine(FadeOut(fadeOutTime, currentSource));
                    currentSource.Stop();
                }
                );
            }
        }
    }

    private void SetValues(AudioSource source, AudioClip clip, (float volume, float pitch) volume_pitch, bool loop)
    {
        if (source.volume != volume_pitch.volume) source.volume = volume_pitch.volume;
        if (source.pitch != volume_pitch.pitch) source.pitch = volume_pitch.pitch;
        if (source.clip != clip) source.clip = clip;
        if (source.loop != loop) source.loop = loop;
    }

    private IEnumerator Fade(bool fadeIn, float time, AudioSource audioSource, float targetVolume)
    {
        if(!fadeIn)
        {

        }

        audioSource.volume = 0;
        float actTime = 0;
        float startVolume =audioSource.volume;
        while (actTime <= )
        {
            audioSource.volume += volumeUp;
            actTime += _timeToWait;
            yield return new WaitForSecondsRealtime(_timeToWait);
        }
        audioSource.volume = targetVolume;
    }
    private IEnumerator FadeOut( float time, AudioSource audioSource, )
    {
        Debug.Log("Bajando volumen, volumen a: " + audioSource.volume);
        audioSource.volume = audioSource.volume;
        float actTime = 0;
        float volumeDown = _timeToWait / time;
        while (actTime <= time)
        {
            audioSource.volume -= volumeDown;
            Debug.Log(audioSource.volume+", "+ volumeDown);
            actTime += _timeToWait;
            yield return new WaitForSecondsRealtime(_timeToWait);
        }
        audioSource.volume = 0;
        Debug.Log("Yo ya");
    }
}
