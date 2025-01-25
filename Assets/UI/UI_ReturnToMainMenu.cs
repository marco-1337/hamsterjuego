using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_ReturnToMainMenu : MonoBehaviour
{
    [SerializeField]private Guardado guardado;
    [SerializeField] private Pipas pipas;
    [SerializeField] private GameObject player;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ChangeToMainMenu);
    }

    private void ChangeToMainMenu()
    {
        SaveGame();
        SceneManager.LoadScene("MainMenu");
    }

    private void SaveGame()
    {
        guardado._savedPlayerTransform = player.transform;
        guardado._savedPipas = pipas.numPipas;
    }

}
