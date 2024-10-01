using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class CameraScript : MonoBehaviour
{
    [SerializeField] float _acceleration;
    SplineAnimate _splineAnimate;
    
    void Start()
    {
        _splineAnimate = GetComponent<SplineAnimate>();
    }
    
    void Update()
    {
        _splineAnimate.MaxSpeed += _acceleration * Time.deltaTime;
    }

    public void RestartCamera()
    {
        _splineAnimate.ElapsedTime = 0;
        _splineAnimate.MaxSpeed = 0;
    }
}
