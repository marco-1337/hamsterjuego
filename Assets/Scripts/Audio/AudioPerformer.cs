using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Este script busca todos los Audio players (scriptable objects) dentro de una carpeta y genera un audio source (que permite reproducir el sonido)
 * por cada uno de estos.
*/
public class AudioPerformer : MonoBehaviour
{

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

                _audioPlayer[i].OnAudioOneShotPlay.
                AddListener((AudioClip clip, (float volume, float pitch) volume_pitch, (float fadeInTime, float _fadeOutTime) fadeInOutTime, bool loop) =>
                {
                    if (currentSource.volume != volume_pitch.volume) currentSource.volume = volume_pitch.volume;
                    if (currentSource.pitch != volume_pitch.pitch) currentSource.pitch = volume_pitch.pitch;
                    if (currentSource.clip != clip) currentSource.clip = clip;
                    if (currentSource.loop != loop) currentSource.loop = loop;

                    currentSource.Play();
                }
                );

                _audioPlayer[i].OnAudioPlay.
                AddListener((AudioClip clip, (float volume, float pitch) volume_pitch, (float fadeInTime, float _fadeOutTime) fadeInOutTime, bool loop) =>
                {
                    if (currentSource.volume != volume_pitch.volume) currentSource.volume = volume_pitch.volume;
                    if (currentSource.pitch != volume_pitch.pitch) currentSource.pitch = volume_pitch.pitch;
                    if (currentSource.clip != clip) currentSource.clip = clip;
                    if (currentSource.loop != loop) currentSource.loop = loop;

                    currentSource.PlayOneShot(clip);
                }
                );

                _audioPlayer[i].OnAudioStop.AddListener(() => currentSource.Stop());
            }
        }
    }
}
