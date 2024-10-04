using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeScript : MonoBehaviour
{
    float _time;
    public int DeathCount;

    void Start()
    {
        
    }

    void Update()
    {
        _time = Time.time;
        float totalTime = Time.time;
        int minutes = (int)(totalTime / 60);
        int seconds = (int)(totalTime % 60);
        int milliseconds = (int)((totalTime - (int)totalTime) * 1000);

        GetComponent<TextMeshProUGUI>().text = $"TIME: {minutes:D2}:{seconds:D2}:{milliseconds:D3}";
    }
}
