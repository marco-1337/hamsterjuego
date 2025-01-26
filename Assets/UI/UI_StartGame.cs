using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_StartGame : MonoBehaviour
{
    [SerializeField] UnityEvent startMusic;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(StartGameScene);
        startMusic.Invoke();
    }

    private void StartGameScene()
    {
        Debug.Log("A");
        SceneManager.LoadScene("Cinematica");
    }
}
