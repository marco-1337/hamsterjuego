
using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CreditController : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _playMusic;

    [SerializeField]
    private UnityEvent _stopMusic;

    private Timer _timer;
    // Start is called before the first frame update
    void Start()
    {
        _playMusic.Invoke();
        StartCoroutine(Tiempo());
    }

    private IEnumerator Tiempo()
    {
        yield return new WaitForSeconds(10);
        _stopMusic.Invoke();
        SceneManager.LoadScene("MainMenu");
    }

}
