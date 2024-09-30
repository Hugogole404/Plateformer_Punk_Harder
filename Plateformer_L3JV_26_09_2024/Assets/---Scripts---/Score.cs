using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _textScore;
    [Header("Bumpers")]
    [SerializeField] private int _scoreGivenBumpers;
    private int _actualScore;

    public void AddScoreBumpers()
    {
        _actualScore += _scoreGivenBumpers;
        _textScore.text = $"Score : {_actualScore}";
    }
}