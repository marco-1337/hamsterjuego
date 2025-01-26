using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_CloseApp : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(CloseApp);
    }

    private void CloseApp()
    {
        Application.Quit();
    }

}
