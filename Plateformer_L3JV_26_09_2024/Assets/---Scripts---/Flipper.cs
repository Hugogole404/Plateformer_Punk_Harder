using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    GameObject _other;

    [Header("Parameter :")]
    [SerializeField] float _force;

    [Header("Programmer only")]
    [SerializeField] float _rotationZFinal;
    [SerializeField] float _rotationZStart;
    [SerializeField] float _forceX;

    void OnTriggerEnter2D(Collider2D collision)
    {
        _other = collision.gameObject;
        launchOther(_other);
    }

    void launchOther(GameObject other)
    {
        if (other.GetComponent<Rigidbody2D>() != null)
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(_forceX * _force, 1 * _force);
            playAnim();
        }
    }

    void playAnim()
    {

        transform.DORotate(new Vector3(0, 0, _rotationZFinal), .1f).OnComplete(playAnimBackward);
    }

    void playAnimBackward()
    {
        transform.DORotate(new Vector3(0, 0, _rotationZStart), .2f);
    }

}