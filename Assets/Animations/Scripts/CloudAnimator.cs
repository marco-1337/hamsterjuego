using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(AnimationCoroutine());
    }

    private IEnumerator AnimationCoroutine()
    {
        _animator.SetBool("Hit", true);
        yield return new WaitForSeconds(0.2f);
        _animator.SetBool("Hit", false);
    }
}
