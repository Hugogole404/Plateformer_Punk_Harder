using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor.Rendering;
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
    private float _currentTimerBetweenJumps;
    private int _currentNumbOfJumps;
    private Vector2 _inputs;
    private Vector2 _direction = Vector2.zero;
    private bool _canJump;
    private bool _isGrounded;

    private void Start()
    {
        TeleportPlayerToSpawnPoint();
        _currentTimerBetweenJumps = 0;
    }
    private void Update()
    {
        _currentTimerBetweenJumps += Time.deltaTime;
    }
    private void FixedUpdate()
    {
        ApplyMovements();
    }

    public void TeleportPlayerToSpawnPoint()
    {
        if (_spawnPoint != null)
            transform.position = _spawnPoint.transform.position;
    }
    public void Move(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            //_rigidbody.velocity
        }
        _inputs = context.ReadValue<Vector2>();
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        CheckJumpConditions();
        if (_canJump)
        {
        }
        _rigidbody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
    }
    private void ApplyMovements()
    {
        _rigidbody.AddForce(new Vector2(0, 1) * _gravity * _gravityMultiplier, ForceMode2D.Force);
        _rigidbody.AddForce(_inputs * _speed, ForceMode2D.Force);
    }
    //private void CheckIsGrounded()
    //{
    //    _currentNumbOfJumps = 0;
    //}
    private void CheckJumpConditions()
    {
        if (_minTimerBetweenJumps <= _currentTimerBetweenJumps && _numberOfJumps > _currentTimerBetweenJumps)
        {
            _currentTimerBetweenJumps = 0;
            _canJump = true;
        }
        else
        {
            _canJump = false;
        }
    }
}