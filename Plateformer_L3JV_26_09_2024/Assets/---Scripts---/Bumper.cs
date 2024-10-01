using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class Bumper : MonoBehaviour
{
    [SerializeField] GameObject _thisGO;
    [SerializeField] Score _score;
    [SerializeField] AudioClip _sound;
    [SerializeField] float _maxTimerBetweenGetScore;
    private float _currentTimerBetweenGetScore;
    private bool _canTimer;

    private void Start()
    {
        _canTimer = false;
    }
    private void Update()
    {
        CheckTimer();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            _thisGO.transform.DOComplete();
            _thisGO.transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0), 0.3f, 2, 0.3f);
            if (!_canTimer)
            {
                _score.AddScoreBumpers();

                _score.GetSound(_sound);
                _score.PlaySound();

                _canTimer = true;
            }
        }
    }
    private void CheckTimer()
    {
        if (_canTimer)
        {
            _currentTimerBetweenGetScore += Time.deltaTime;
            if (_currentTimerBetweenGetScore > _maxTimerBetweenGetScore)
            {
                _currentTimerBetweenGetScore = 0;
                _canTimer = false;
            }
        }
    }
}