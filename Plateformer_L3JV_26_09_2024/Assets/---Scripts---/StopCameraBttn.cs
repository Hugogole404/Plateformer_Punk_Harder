using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class StopCameraBttn : MonoBehaviour
{
    [SerializeField] float _saveSplineSpeed;
    [SerializeField] float _timer;

    [SerializeField] GameObject _mainCamera;
    SplineAnimate _splineAnimate;

    bool _isStopping = false;
    bool _isWaiting = true;

    private void Start()
    {
        _splineAnimate = _mainCamera.GetComponent<SplineAnimate>();
    }

    private void Update()
    {
        if (_isStopping)
        {
            _splineAnimate.ElapsedTime -= Time.deltaTime;
            _splineAnimate.MaxSpeed = _saveSplineSpeed;
        }

        if (_isWaiting)
            _timer = 0;
        else _timer += Time.deltaTime;

        if (_timer > 3)
        {
            _isStopping = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            _isStopping = true;
            _saveSplineSpeed = _splineAnimate.MaxSpeed;
            _isWaiting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            _isWaiting = false;
        }
    }


}
