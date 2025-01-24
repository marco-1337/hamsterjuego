using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_StartGame : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(StartGameScene);
    }

    private void StartGameScene()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
