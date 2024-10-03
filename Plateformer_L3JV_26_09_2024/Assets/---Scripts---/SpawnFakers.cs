using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFakers : MonoBehaviour
{
    [SerializeField] private float _maxTimerBetweenSpawnBalls;
    [SerializeField] private float _range;
    [SerializeField] private GameObject _prefabBall;
    private float _currentTimerBetweenSpawnBalls;

    private void Update()
    {
        SpawnTimer();
    }

    private void SpawnTimer()
    {
        _currentTimerBetweenSpawnBalls += Time.deltaTime;

        if (_currentTimerBetweenSpawnBalls >= _maxTimerBetweenSpawnBalls)
        {
            _currentTimerBetweenSpawnBalls = 0;
            float rand = Random.Range(- _range, _range);
            Instantiate(_prefabBall, new Vector3(transform.position.x + rand, transform.position.y), Quaternion.identity);
        }
    }
}