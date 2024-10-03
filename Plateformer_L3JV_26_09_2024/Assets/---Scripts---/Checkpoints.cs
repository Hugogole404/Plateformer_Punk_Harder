using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class Checkpoints : MonoBehaviour
{
    public GameObject _spawnPoint;
    public float TimeForCamera;
    public SplineAnimate Spline;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            collision.gameObject.GetComponent<PlayerController>()._spawnPoint = _spawnPoint;
        }
    }
}