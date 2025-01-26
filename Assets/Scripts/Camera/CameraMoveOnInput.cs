using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMoveOnInput : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _playerCenter;

    [SerializeField] private float _maxDistance;

    private bool _move;
    private Vector2 _direction;

    public void Move(Vector2 direction)
    {
        _direction = direction;
        _move = true;
    }

    public void StopMoving()
    {
        _direction = Vector2.zero;
        _move = false;
    }

    private void Update()
    {
        if (_move)
        {
            transform.position = Vector2.Lerp(transform.position, (Vector2)transform.position + (_direction * _speed), 2 * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, -7);

            if (transform.position.y > _playerCenter.transform.position.y + _maxDistance) 
                transform.position = new Vector3(transform.position.x, _playerCenter.transform.position.y + _maxDistance, -7);
            else if (transform.position.y < _playerCenter.transform.position.y - _maxDistance)
                transform.position = new Vector3(transform.position.x, _playerCenter.transform.position.y - _maxDistance, - 7);

            if (transform.position.x > _playerCenter.transform.position.x + _maxDistance)
                transform.position = new Vector3(_playerCenter.transform.position.x + _maxDistance, transform.position.y, -7);
            else if(transform.position.x < _playerCenter.transform.position.x - _maxDistance)
                transform.position = new Vector3(_playerCenter.transform.position.x - _maxDistance, transform.position.y, -7);
        }
    }
}
