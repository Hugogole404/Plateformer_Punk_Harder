using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Splines;

public class CameraScript : MonoBehaviour
{
    public float _acceleration;
    [SerializeField] float _bonusTime;
    SplineAnimate _splineAnimate;

    bool _bonusSpeedEnabled = false;
    [SerializeField] BoxCollider2D _upCollision;
    [SerializeField] BoxCollider2D _rightCollision;

    private Vector3 lastPosition;
    private float deltaTime;

    void Start()
    {
        _splineAnimate = GetComponent<SplineAnimate>();

        lastPosition = transform.position;
    }
    
    void Update()
    {
        _splineAnimate.MaxSpeed += _acceleration * Time.deltaTime;

        if (_bonusSpeedEnabled)
            _splineAnimate.ElapsedTime += _bonusTime;

        float horizontalSpeed, verticalSpeed;

        ComputeVelocity(out horizontalSpeed, out verticalSpeed);

        if (horizontalSpeed > verticalSpeed)
        {
            _upCollision.enabled = false;
            _rightCollision.enabled = true;
        }
        else
        {
            _upCollision.enabled = true;
            _rightCollision.enabled = false;
        }
    }

    private void ComputeVelocity(out float horizontalSpeed, out float verticalSpeed)
    {
        Vector3 currentPosition = transform.position;

        Vector3 displacement = currentPosition - lastPosition;

        horizontalSpeed = displacement.x / Time.deltaTime;
        verticalSpeed = displacement.y / Time.deltaTime;
        lastPosition = currentPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
            _bonusSpeedEnabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
            _bonusSpeedEnabled = false;
    }

    public void RestartCamera(PlayerController player)
    {
        if (player._spawnPoint.GetComponentInParent<Checkpoints>() != null)
        {
            float timeSpline = player._spawnPoint.GetComponentInParent<Checkpoints>().TimeForCamera;
            _splineAnimate.ElapsedTime = timeSpline;
        }
        else
        {
            _splineAnimate.ElapsedTime = 0;
            _splineAnimate.MaxSpeed = 0.5f;
        }
    }
}
