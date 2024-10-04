using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using DG.Tweening;

public class StopCameraBttn : MonoBehaviour
{
    [SerializeField] float _saveSplineSpeed;
    [SerializeField] float _timer;

    [SerializeField] Sprite _activatedSprite;

    [SerializeField] GameObject _mainCamera;
    [SerializeField] List<GameObject> _listFeedBackStopCam;

    Sprite _oldSprite;
    SpriteRenderer _actualSprite;
    SplineAnimate _splineAnimate;

    bool _isStopping = false;
    bool _isWaiting = true;


    private void Start()
    {
        _splineAnimate = _mainCamera.GetComponent<SplineAnimate>();
        _actualSprite = gameObject.GetComponent<SpriteRenderer>();
        _oldSprite = _actualSprite.sprite;
    }

    private void Update()
    {
        if (_isStopping)
        {
            _splineAnimate.ElapsedTime -= Time.deltaTime;
            _splineAnimate.MaxSpeed = _saveSplineSpeed;
            _actualSprite.sprite = _activatedSprite;
            if (_listFeedBackStopCam.Count > 0)
            {
                for (int i = 0; i < _listFeedBackStopCam.Count; i++)
                {
                    _listFeedBackStopCam[i].gameObject.SetActive(true);
                }
            }
            //ShakeStopCam();
        }

        if (_isWaiting)
            _timer = 0;
        else _timer += Time.deltaTime;

        if (_timer > 3)
        {
            _isStopping = false;
            _actualSprite.sprite = _oldSprite;
            if (_listFeedBackStopCam.Count > 0)
            {
                for (int i = 0; i < _listFeedBackStopCam.Count; i++)
                {
                    _listFeedBackStopCam[i].gameObject.SetActive(false);
                }
            }
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

    private void ShakeStopCam()
    {
        for (int i = 0; i < _listFeedBackStopCam.Count; i++)
        {
            _listFeedBackStopCam[i].gameObject.transform.DOShakePosition(20, 10);
            if (i == _listFeedBackStopCam.Count)
                i = 0;
        }
    }
}
