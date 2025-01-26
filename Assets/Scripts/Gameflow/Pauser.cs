using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauser : MonoBehaviour
{
    [SerializeField] private GameObject _pauseUIObject;
    bool _paused = false;

    public void Pause()
    {
        _paused = !_paused;
        _pauseUIObject.SetActive(_paused);
        Time.timeScale = _paused ?  0.0f : 1.0f;
    }
}
