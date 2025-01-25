
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CinematicManager : MonoBehaviour
{
    [SerializeField] private Sprite[] imagesOfCinematic;
    [SerializeField] private float timeOfImage = 1;
    [SerializeField] private Image image;

    private void Start()
    {
        StartCoroutine(Cinematic());
    }

    private IEnumerator Cinematic()
    {
        for (int i = 0; i < imagesOfCinematic.Length; i++)
        {
            //cosas
            image.sprite = imagesOfCinematic[i];
            yield return new WaitForSeconds(timeOfImage);
        }

        SceneManager.LoadScene("MainScene");
    }
}
