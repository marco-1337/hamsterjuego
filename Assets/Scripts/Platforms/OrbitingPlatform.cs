using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitingPlatform : MonoBehaviour
{
    [SerializeField] private float _timeForShift, _speed;

    private Vector2 _direction;

    private void Start()
    {
        _direction = new Vector2(0, 1);
        StartCoroutine(FloatingCoroutine());
    }

    private void Update()
    {
        transform.position = ((Vector2)transform.position + (_direction * _speed * Time.deltaTime));
    }

    private IEnumerator FloatingCoroutine()
    {
        yield return new WaitForSeconds(_timeForShift);
        _direction = -_direction; 
    }
}
