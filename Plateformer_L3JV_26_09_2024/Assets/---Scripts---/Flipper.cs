using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    GameObject _other;
    [SerializeField] float _force;

    void OnTriggerEnter2D(Collider2D collision)
    {
        _other = collision.gameObject;
        launchOther(_other);
    }

    void launchOther(GameObject other)
    {
        if (other.GetComponent<Rigidbody2D>() != null)
            other.GetComponent<Rigidbody2D>().AddForce(new Vector2(1 * _force, 1 * _force), ForceMode2D.Impulse);
    }

    void Update()
    {
        
    }

    void playAnim()
    {

    }

    void playAnimBackward()
    {

    }

}