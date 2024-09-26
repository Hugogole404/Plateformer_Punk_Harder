using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movements")]
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody;
    [Header("Jumps")]
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _numberOfJumps;
    [SerializeField] private float _minTimerBetweenJumps;
    [Header("Spawn Point")]
    [SerializeField] private GameObject _spawnPoint;
    [Header("Gravity")]
    [SerializeField] private float _gravityMultiplier;

    private float _gravity = -9.81f;
    private Vector2 _inputs;
    private Vector2 _direction = Vector2.zero;
    private bool _inputJump;
    private bool _isGrounded;

    private void Start()
    {
        TeleportPlayerToSpawnPoint();
    }
    private void Update()
    {
        Debug.Log(_inputs);
    }
    private void FixedUpdate()
    {
        ApplyMovements();
    }

    public void TeleportPlayerToSpawnPoint()
    {
        transform.position = _spawnPoint.transform.position;
    }
    public void Move(InputAction.CallbackContext context)
    {
        _inputs = context.ReadValue<Vector2>();
        //_direction = new Vector3(_inputs.x, _inputs.y);
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        _rigidbody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
    }
    private void ApplyMovements()
    {
        
        _rigidbody.AddForce(_inputs * _speed, ForceMode2D.Force);
    }
}