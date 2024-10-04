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
    //[SerializeField] Player _deathsObj;

    public int DeathCount;

    void Update()
    {
        float totalTime = Time.time;
        int minutes = (int)(totalTime / 60);
        int seconds = (int)(totalTime % 60);
        int milliseconds = (int)((totalTime - (int)totalTime) * 1000);

        _timeObj.GetComponent<TextMeshProUGUI>().text = $"TIME: {minutes:D2}:{seconds:D2}:{milliseconds:D3}";
        _scoreObj.GetComponent<TextMeshProUGUI>().text = $"SCORE: {_scoreScript.ActualScore}";
        _deathsObj.GetComponent<TextMeshProUGUI>().text = $"SCORE: {_scoreScript.ActualScore}";
    }
}
