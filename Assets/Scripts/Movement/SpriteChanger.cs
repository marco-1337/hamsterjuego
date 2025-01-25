using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    [SerializeField]
    private Sprite _idle;
    [SerializeField]
    private Sprite _dizzy;
    
    private SpriteRenderer _renderer;
    private MovementComponent _movement;

    private void ChangeSprite(Sprite sprite)
    {
        _renderer.sprite = sprite;
    }


    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _movement = GetComponent<MovementComponent>();
    }

    void Update()
    {
        if(_renderer.sprite != _dizzy && _movement.IsMoving())
            ChangeSprite(_dizzy);
        else if(_renderer.sprite != _idle && !_movement.IsMoving())
            ChangeSprite(_idle);
    }
}
