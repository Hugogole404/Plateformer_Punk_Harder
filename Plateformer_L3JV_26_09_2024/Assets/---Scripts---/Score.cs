using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private AudioSource AudioSourceBumpers;
    [SerializeField] private TextMeshProUGUI _textScore;
    public int DeathCount;

    [Header("Bumpers")]
    public int ActualScore;

    public void AddScoreBumpers(int givenScore)
    {
        ActualScore += givenScore;
        _textScore.text = $"Score : {ActualScore}";
    }
    public void PlaySound()
    {
        AudioSourceBumpers.Play();
    }
    public void GetSound(AudioClip clip)
    {
        AudioSourceBumpers.clip = clip;
    }
    public void ReinitScore()
    {
        ActualScore = 0;
        _textScore.text = $"Score : {ActualScore}";
    }
}