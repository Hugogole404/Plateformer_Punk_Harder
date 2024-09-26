using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] float _distance;
    [SerializeField] float _time;
    [SerializeField] bool _sens;
    Vector2 _position;
    float _offset = 0;

    // Start is called before the first frame update
    void Start()
    {
        _position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _offset += Time.deltaTime;
        print(Mathf.Sin(_offset));
        transform.position = new Vector2(Mathf.Sin(_offset * _distance * 4), 0);
    }
}
