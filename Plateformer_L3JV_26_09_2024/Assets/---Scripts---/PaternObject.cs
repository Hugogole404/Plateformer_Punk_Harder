using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaternObject : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float _distanceX;
    [SerializeField] float _distanceY;
    [SerializeField] float _AnimationTime;
    [SerializeField] bool circle;

    [HideInInspector] public float OffsetX = 0f;
    [HideInInspector] public float OffsetY = 0f;
    Vector2 _positionInitial;
    

    void Start()
    {
        if ((_distanceX == 0f && _distanceY == 0f) || _AnimationTime == 0)
        {
            Destroy(this);
            return;
        }

        _positionInitial = transform.position;
        _positionInitial.x += _distanceX;
        _positionInitial.y += _distanceY;
    }

    // Update is called once per frame
    void Update()
    {
        float resultX;
        float resultY;

        OffsetX += Time.deltaTime * Mathf.PI / _AnimationTime * 2;
        OffsetY += Time.deltaTime * Mathf.PI / _AnimationTime * 2;
        if (circle)
            resultX = Mathf.Sin(OffsetX + Mathf.PI / 2) * _distanceX;
        else
            resultX = Mathf.Sin(OffsetX) * _distanceX;

        resultY = Mathf.Sin(OffsetY) * _distanceY;
        transform.position = new Vector3(_positionInitial.x + resultX, _positionInitial.y + resultY);
    }
}
