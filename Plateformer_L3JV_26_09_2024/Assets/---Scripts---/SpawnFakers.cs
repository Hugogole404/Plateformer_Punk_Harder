using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFakers : MonoBehaviour
{
    [SerializeField] private float _maxTimerBetweenSpawnBalls;
    [SerializeField] private GameObject _prefabBall;
    private float _currentTimerBetweenSpawnBalls;

    private void Update()
    {
        SpawnTimer();
    }

    private void SpawnTimer()
    {
        //if()
    }
}