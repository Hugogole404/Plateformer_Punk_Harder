using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class PatternObject : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float _distanceX;
    [SerializeField] float _distanceY;
    [SerializeField, FormerlySerializedAs("_AnimationTime")] float _animationTime;
    [SerializeField, FormerlySerializedAs("circle")] bool _circle;

    [HideInInspector] public float OffsetX = 0f;
    [HideInInspector] public float OffsetY = 0f;
    Vector2 _positionInitial;

    [FormerlySerializedAs("PosX")] private float _posX;
    [FormerlySerializedAs("PosY")] private float _posY;  
    [FormerlySerializedAs("NextPosX")] private float _nextPosX;
    [FormerlySerializedAs("NextPosY")] private float _nextPosY;
    [HideInInspector] public float OffsetPlatX;
    [HideInInspector] public float OffsetPlatY;
    

    void Start()
    {
        if ((_distanceX == 0f && _distanceY == 0f) || _animationTime == 0)
        {
            Destroy(this);
            return;
        }

        _positionInitial = transform.position;
        _positionInitial.x += _distanceX;
        _positionInitial.y += _distanceY;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float resultX;
        float resultY;


        OffsetX += Time.deltaTime * Mathf.PI / _animationTime * 2;
        OffsetY += Time.deltaTime * Mathf.PI / _animationTime * 2;

        if (_circle)
            resultX = Mathf.Sin(OffsetX + Mathf.PI / 2) * _distanceX;
        else
            resultX = Mathf.Sin(OffsetX) * _distanceX;

        resultY = Mathf.Sin(OffsetY) * _distanceY;
        _posX = transform.position.x;
        _posY = transform.position.y;

        transform.position = new Vector3(_positionInitial.x + resultX, _positionInitial.y + resultY);

        _nextPosX = transform.position.x;
        _nextPosY = transform.position.y;

        OffsetPlatX = _nextPosX - _posX;
        OffsetPlatY = _nextPosY - _posY;
    }
}
