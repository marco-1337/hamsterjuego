
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CinematicManager : MonoBehaviour
{
    [SerializeField] private Sprite[] imagesOfCinematic;
    [SerializeField] private float timeOfImage = 1;
    [SerializeField] private Image image;
    [SerializeField] private UnityEvent startMusic, stopMusic;
    private void Start()
    {
        Time.timeScale = 1.0f;
        StartCoroutine(Cinematic());
        startMusic.Invoke();
    }

    private IEnumerator Cinematic()
    {
        for (int i = 0; i < imagesOfCinematic.Length; i++)
        {
            //cosas
            image.sprite = imagesOfCinematic[i];
            yield return new WaitForSeconds(timeOfImage);
        }
        LoadNextScene();
    }

    public void SkipCutscene()
    {
        StopAllCoroutines();
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        stopMusic.Invoke();
        SceneManager.LoadScene("MainScene");
    }
}
