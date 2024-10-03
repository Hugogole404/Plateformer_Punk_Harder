using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class CameraScript : MonoBehaviour
{
    public float _acceleration;
    [SerializeField] float _bonusSpeed;
    SplineAnimate _splineAnimate;
    
    void Start()
    {
        _splineAnimate = GetComponent<SplineAnimate>();
    }
    
    void Update()
    {
        _splineAnimate.MaxSpeed += _acceleration * Time.deltaTime * _bonusSpeed;
    }

    public void RestartCamera()
    {
        _splineAnimate.ElapsedTime = 0;
        _splineAnimate.MaxSpeed = 0;
    }
}
