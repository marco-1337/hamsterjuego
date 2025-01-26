using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovimientoCamaraInicial : MonoBehaviour
{
    [SerializeField] Vector2[] recorrido;
    [SerializeField] GameObject player;
    Camera cam;
    [SerializeField] float speed = 5;

    private void Start()
    {
        cam = GetComponent<Camera>();
        StartCoroutine(MovimientoCam());
    }

    private IEnumerator MovimientoCam()
    {
        //player.GetComponent<MovementComponent>().enabled = false;

        for (int i = 0; i < recorrido.Length; i++)
        {
            Vector2 posPlayer = new Vector2(player.transform.position.x, player.transform.position.y);

            while ((posPlayer - recorrido[i]).magnitude > 30)
            {
                Debug.Log((posPlayer - recorrido[i]).magnitude);
                Vector2 dir = -(recorrido[i] - posPlayer).normalized;
                cam.transform.parent.position += new Vector3(dir.x, dir.y, 0) * speed * Time.deltaTime;
                posPlayer = new Vector2(player.transform.position.x, player.transform.position.y);
                yield return new WaitForEndOfFrame();
            }
        }
        //player.GetComponent<MovementComponent>().enabled = true;
        cam.enabled = false;
    }
}
