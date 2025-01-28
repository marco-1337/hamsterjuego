
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

    [SerializeField]
    private int _time = 30;

    private Timer _timer;
    // Start is called before the first frame update
    void Start()
    {
        _playMusic.Invoke();
        StartCoroutine(Tiempo());
    }

    private IEnumerator Tiempo()
    {
        yield return new WaitForSeconds(_time);
        _stopMusic.Invoke();
        SceneManager.LoadScene("MainMenu");
    }

}
