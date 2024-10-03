using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public float Timer;
    public float TimeBeforePressed;
    public GameObject Countdown;
    public KeyCode _keyCode;

    float _timeLeft;

    void Update()
    {
        TimeBeforePressed -= Time.deltaTime;

        if ((Input.GetKey(_keyCode)) && (TimeBeforePressed < 0))
        {
            _timeLeft += Time.deltaTime / Timer;

            if (Countdown.GetComponent<Image>().fillAmount == 1)
            {
                string currentSceneName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(currentSceneName);
            }
        }
        else if (Input.GetKeyUp(_keyCode))
        {
            _timeLeft = 0;
        }


        Countdown.GetComponent<Image>().fillAmount = _timeLeft;
    }
}
