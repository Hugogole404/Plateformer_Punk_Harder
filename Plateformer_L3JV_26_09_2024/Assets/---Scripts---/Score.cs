using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] int _actualScore;
    [SerializeField] TextMeshProUGUI _textScore;
    [Header("Bumpers")]
    private int _scoreGivenBumpers;

    public void AddScoreBumpers()
    {
        _actualScore += _scoreGivenBumpers;
        _textScore.text = $"Score : {_actualScore}";
    }
}