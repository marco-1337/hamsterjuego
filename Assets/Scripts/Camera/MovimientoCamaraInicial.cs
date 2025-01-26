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
        player.SetActive(false);

        for (int i = 0; i < recorrido.Length; i++)
        {
            Vector2 posCam = new Vector2(cam.transform.parent.position.x, cam.transform.parent.position.y);

            while ((posCam - recorrido[i]).magnitude > 3)
            {
                Debug.Log((posCam - recorrido[i]).magnitude);
                Vector2 dir = (recorrido[i] - posCam).normalized;
                cam.transform.parent.position += new Vector3(dir.x, dir.y, 0) * speed * Time.deltaTime;
                posCam = new Vector2(cam.transform.parent.position.x, cam.transform.parent.position.y);
                yield return new WaitForEndOfFrame();
            }
        }
        player.SetActive(true);
        cam.enabled = false;
    }
}
