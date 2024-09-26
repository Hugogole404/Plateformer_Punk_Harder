using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] float _distanceX;
    [SerializeField] float _distanceY;
    [SerializeField] float _AnimationTime;
    [SerializeField] bool circle;

    float _offsetX = 0f;
    float _offsetY = 0f;
    Vector2 _positionInitial;
    

    // Start is called before the first frame update
    void Start()
    {
        if ((_distanceX == 0f && _distanceY == 0f) || _AnimationTime == 0)
        {
            Destroy(this);
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

        _offsetX += Time.deltaTime * Mathf.PI / _AnimationTime * 2;
        _offsetY += Time.deltaTime * Mathf.PI / _AnimationTime * 2;
        if (circle)
            resultX = Mathf.Sin(_offsetX + Mathf.PI / 2) * _distanceX;
        else
            resultX = Mathf.Sin(_offsetX) * _distanceX;

        resultY = Mathf.Sin(_offsetY) * _distanceY;
        transform.position = new Vector3(_positionInitial.x + resultX, _positionInitial.y + resultY);
    }
}
