using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private AudioSource AudioSourceBumpers;
    [SerializeField] private TextMeshProUGUI _textScore;

    [Header("Bumpers")]
    [SerializeField] private int _scoreGivenBumpers;
    private int _actualScore;

    public void AddScoreBumpers()
    {
        _actualScore += _scoreGivenBumpers;
        _textScore.text = $"Score : {_actualScore}";
    }
    public void PlaySound()
    {
        AudioSourceBumpers.Play();
    }
    public void GetSound(AudioClip clip)
    {
        AudioSourceBumpers.clip = clip;
    }
}