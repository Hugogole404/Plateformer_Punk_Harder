using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraIntro : MonoBehaviour
{
    float _Ypos = 0;
    [SerializeField] float _speed;
    [SerializeField] float _endY;
    [SerializeField] float _slowPower;
    [SerializeField] GameObject _mainCamera;

    void Update()
    {
        if (_endY > _Ypos) 
        {
            _mainCamera.SetActive(true);
            Destroy(gameObject);
            return;
        }

        if (_endY + 10 > _Ypos)
        {
            _speed -= Time.deltaTime * _slowPower;
        }

        if (gameObject.GetComponent<Camera>().enabled)
        {
            gameObject.GetComponent<Camera>().enabled = true;
        }

        _Ypos -= _speed * Time.deltaTime;
        gameObject.transform.position = new Vector3(0, _Ypos, 0);
    }
}
