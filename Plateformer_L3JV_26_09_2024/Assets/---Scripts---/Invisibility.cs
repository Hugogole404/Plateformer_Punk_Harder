using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour
{
    [Header("Invisibility")]
    [SerializeField] float _visibleTime;
    [SerializeField] float _invisibleTime;
    [SerializeField] bool _startVisible;

    void Start()
    {
        if (_visibleTime <= 0 || _invisibleTime <= 0)
        {
            Destroy(this);
            return;
        }

        if (_startVisible)
            StartCoroutine(Visible());
        else StartCoroutine(Invisible());
    }

    IEnumerator Invisible()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;

        yield return new WaitForSeconds(_invisibleTime);

        StartCoroutine(Visible());
    }

    IEnumerator Visible()
    {
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;

        yield return new WaitForSeconds(_visibleTime);

        StartCoroutine(Invisible());
    }
}
