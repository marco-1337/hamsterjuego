using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                AddListener((AudioClip clip, (float volume, float pitch) volume_pitch, (float fadeInTime, float _fadeOutTime) fadeInOutTime, bool loop) =>
                {
                    SetValues(currentSource, clip, volume_pitch, fadeInOutTime, loop);
                }
                );

                _audioPlayer[i].OnAudioOneShotPlay.
                AddListener((AudioClip clip, (float volume, float pitch) volume_pitch, (float fadeInTime, float _fadeOutTime) fadeInOutTime, bool loop) =>
                {
                    SetValues(currentSource, clip, (0, volume_pitch.pitch), fadeInOutTime, loop);
                    currentSource.Play();

                }
                );

                _audioPlayer[i].OnAudioPlay.
                AddListener((AudioClip clip, (float volume, float pitch) volume_pitch, (float fadeInTime, float _fadeOutTime) fadeInOutTime, bool loop) =>
                {
                    SetValues(currentSource, clip, volume_pitch, fadeInOutTime, loop);
                    currentSource.PlayOneShot(clip);
                }
                );

                _audioPlayer[i].OnAudioStop.AddListener(() => currentSource.Stop());
            }
        }
    }

    private void SetValues(AudioSource source, AudioClip clip, (float volume, float pitch) volume_pitch, (float fadeInTime, float _fadeOutTime) fadeInOutTime, bool loop)
    {
        if (source.volume != volume_pitch.volume) source.volume = volume_pitch.volume;
        if (source.pitch != volume_pitch.pitch) source.pitch = volume_pitch.pitch;
        if (source.clip != clip) source.clip = clip;
        if (source.loop != loop) source.loop = loop;
    }

    private IEnumerator(float time)
    {
        float actTime = 0;
        while (actTime<= time)
        {
            actTime += _timeToWait;
            yield return new WaitForSecondsRealtime(_timeToWait);
        }
        yield return new WaitForSecondsRealtime(_timeToWait);


    }
}
