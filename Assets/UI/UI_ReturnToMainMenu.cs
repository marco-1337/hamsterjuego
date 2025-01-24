using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_ReturnToMainMenu : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ChangeToMainMenu);
    }

    private void ChangeToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
