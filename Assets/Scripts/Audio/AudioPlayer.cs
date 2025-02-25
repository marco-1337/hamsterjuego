using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Events;

/*
 * Este escript permite crear scriptable objects que guardaran una o varias pistas de audio. 
 * Los scriptable objects tendr�n varias funciones que permitir�n manejar tanto efectos de sonido como m�sica.
 * Estos Audio Players se suscribiran a eventos para ser reproducidos
*/
[CreateAssetMenu(fileName = "NewSoundEffect", menuName = "Audio/New Sound Effect")]
public class AudioPlayer : ScriptableObject
{
    public AudioClip[] clips;
    public Vector2 volume = new Vector2(1f, 1f);
    public Vector2 pitch = new Vector2(1f, 1f);
    [SerializeField] private float _fadeInTime = 0.0f, _fadeOutTime = 0.0f;
    [SerializeField] int playIndex;
    [SerializeField] private SoundClipOrder playOrder;
    [SerializeField] private bool _loop;

    #region events
    private UnityEvent<AudioClip, (float, float), bool> _onLoadMuic = new UnityEvent<AudioClip, (float, float), bool>();
    public UnityEvent<AudioClip, (float, float), bool> OnLoadMusic => _onLoadMuic;

    private UnityEvent<AudioClip, (float, float), float, bool> _onMusicPlay = new UnityEvent<AudioClip, (float, float),  float, bool>();
    public UnityEvent<AudioClip, (float, float), float, bool> OnMusicPlay => _onMusicPlay;

    /*private UnityEvent<AudioClip, (float, float), (float, float), bool> _onAudioPlayFade = new UnityEvent<AudioClip, (float, float), (float, float), bool>();
    public UnityEvent<AudioClip, (float, float), (float, float), bool> OnAudioPlayFadeFade => _onAudioPlayFade;*/

    private UnityEvent<AudioClip, (float, float), float, bool> _onAudioPlay = new UnityEvent<AudioClip, (float, float), float, bool>();
    public UnityEvent<AudioClip, (float, float), float, bool> OnAudioPlay => _onAudioPlay; 

    private UnityEvent<float> onAudioStop = new UnityEvent<float>();
    public UnityEvent<float> OnAudioStop => onAudioStop;
    #endregion

    private AudioClip audioClip()
    {
        //utiliza la pista de audio actual
        var clip = clips[playIndex >= clips.Length ? 0 : playIndex];

        //busca la proxima pista de audio
        switch (playOrder)
        {
            case SoundClipOrder.inOrder:
                playIndex = (playIndex + 1) % clips.Length;
                break;
            case SoundClipOrder.random:
                playIndex = Random.Range(0, clips.Length);
                break;
            case SoundClipOrder.reverse:
                playIndex = (playIndex - 1) % clips.Length;
                break;

        }


        return clip;
    }

    public void LoadMusic()
    {
        if (clips.Length == 0)  //por si acaso falta una pista de audio
        {
            Debug.Log($"Falta el clip de audio {name}");
        }

        float actualVolume = Random.Range(volume.x, volume.y);
        float actualPitch = Random.Range(pitch.x, pitch.y);

        _onLoadMuic?.Invoke(audioClip(), (actualVolume, actualPitch), _loop);
    }
    public void PlayMusic()
    {
        if (clips.Length == 0)  //por si acaso falta una pista de audio
        {
            Debug.Log($"Falta el clip de audio {name}");
        }

        float actualVolume = Random.Range(volume.x, volume.y);
        float actualPitch = Random.Range(pitch.x, pitch.y);

        _onMusicPlay?.Invoke(audioClip(), (actualVolume, actualPitch), _fadeInTime, _loop);
    }
    public void Play()
    {
        if (clips.Length == 0)  //por si acaso falta una pista de audio
        {
            Debug.Log($"Falta el clip de audio {name}");
        }

        float actualVolume = Random.Range(volume.x, volume.y);
        float actualPitch = Random.Range(pitch.x, pitch.y);

        _onAudioPlay?.Invoke(audioClip(), (actualVolume, actualPitch), _fadeInTime, _loop);
    }

    public void Stop() => onAudioStop?.Invoke(_fadeOutTime);


    enum SoundClipOrder
    {
        random,
        inOrder,
        reverse
    }
}