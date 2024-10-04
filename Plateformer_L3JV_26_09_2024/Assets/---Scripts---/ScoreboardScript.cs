using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreboardScript : MonoBehaviour
{
    [SerializeField] GameObject _scoreObj;
    [SerializeField] Score _scoreScript;
    [SerializeField] GameObject _timeObj;
    [SerializeField] GameObject _deathsObj;
    [SerializeField] GameObject _finalScore;

    float _totalScore;

    void Start()
    {
        float totalTime = Time.time;
        int minutes = (int)(totalTime / 60);
        int seconds = (int)(totalTime % 60);
        int milliseconds = (int)((totalTime - (int)totalTime) * 1000);

        _timeObj.GetComponent<TextMeshProUGUI>().text = $"TIME: {minutes:D2}:{seconds:D2}:{milliseconds:D3}";
        _scoreObj.GetComponent<TextMeshProUGUI>().text = $"SCORE: {_scoreScript.ActualScore}";
        _deathsObj.GetComponent<TextMeshProUGUI>().text = $"DEATHS: {_scoreScript.DeathCount}";

        _totalScore = _scoreScript.ActualScore - (300 * _scoreScript.DeathCount);

        if (minutes < 4)
        {
            _totalScore += 10000;
        }
        else if (minutes < 10)
        {
            _totalScore += 5000;
        }
        else if (minutes < 20)
        {
            _totalScore += 2500;
        }
        else if (minutes < 40)
        {
            _totalScore += 1000;
        }
        else 
        {
            _totalScore += 10;
        }

        _finalScore.GetComponent<TextMeshProUGUI>().text = $"FINAL SCORE:{_totalScore}";
    }
}
