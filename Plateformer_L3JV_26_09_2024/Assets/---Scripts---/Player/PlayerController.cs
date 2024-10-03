using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEditor.Rendering;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [Header("Movements")]
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private GameObject _basePlayerParent;
    [Header("Jumps")]
    [SerializeField] private float _jumpForce;
    [SerializeField] private int _maxNumbOFJump;
    private float _currentNumberOfJumps;
    [SerializeField] private float _minTimerBetweenJumps;
    [SerializeField] private LayerMask _layerMask;
    [Header("Spawn Point")]
    [SerializeField] private GameObject _spawnPoint;
    [Header("Gravity")]
    [SerializeField] private float _gravityMultiplier;

    [HideInInspector] public bool IsGrounded;

    private float _gravity = -9.81f;
    private float _currentTimerBetweenJumps;
    private Vector2 _inputs;
    private Vector2 _direction = Vector2.zero;
    private bool _canJump;
    private Vector3 _offset;
    private Transform _toFollow;



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

        if ( _currentPlatform != null)
        {
            transform.position += new Vector3(_currentPlatform.OffsetPlatX, _currentPlatform.OffsetPlatY);
        }
    }

    public void TeleportPlayerToSpawnPoint()
    {
        if (_spawnPoint != null)
        {
            transform.position = _spawnPoint.transform.position;
            _rigidbody.velocity = new Vector3(0, 0, 0);
        }
    }
    public void Move(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            //_rigidbody.velocity /= 2;
        }
        _inputs = context.ReadValue<Vector2>();
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        CheckJumpConditions();
        if (_canJump)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
            _rigidbody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
            _currentNumberOfJumps += 1;
        }
    }
    private void ApplyMovements()
    {
        _rigidbody.AddForce(new Vector2(0, 1) * _gravity * _gravityMultiplier, ForceMode2D.Force);
        _rigidbody.AddForce(_inputs * _speed, ForceMode2D.Force);
    }
    //public void CheckLayerGround(Collider2D collision)
    //{
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & _layerMask) != 0)
        {
            IsGrounded = true;
            _currentNumberOfJumps = 0;

            CheckJumpConditions();
 
            if (collision.gameObject.GetComponent<PaternObject>() != null)
            {
                _currentPlatform = collision.gameObject.GetComponent<PaternObject>();

                //float deltaX = groundCollision.NextPosX - groundCollision.PosX;
                //float deltaY = groundCollision.NextPosY - groundCollision.PosY;
                //_rigidbody.AddForce(new Vector3(deltaX, deltaY) * 200, ForceMode2D.Force);
                //Debug.Log($"{collision.gameObject.name} : {deltaX}, {deltaY}");
                //transform.position += new Vector3(groundCollision.OffsetPlatX, groundCollision.OffsetPlatY) * 10;
                //transform.position += new Vector3(deltaX, deltaY) * 5;
            }
        }
    }
    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (((1 << collision.gameObject.layer) & _layerMask) != 0)
    //    {
    //        if (collision.gameObject.GetComponent<PaternObject>() != null) 
    //        {
    //            PaternObject groundCollision = collision.gameObject.GetComponent<PaternObject>();
    //            //float deltaX = groundCollision.NextPosX - groundCollision.PosX;
    //            //float deltaY = groundCollision.NextPosY - groundCollision.PosY;
    //            //_rigidbody.AddForce(new Vector3(deltaX, deltaY) * 200, ForceMode2D.Force);
    //            //Debug.Log($"{collision.gameObject.name} : {deltaX}, {deltaY}");
    //            transform.position += new Vector3(groundCollision.OffsetPlatX, groundCollision.OffsetPlatY) * 10;
    //            //transform.position += new Vector3(deltaX, deltaY) * 5;
    //        }
    //    }
    //}

    PaternObject _currentPlatform;

    private void CheckJumpConditions()
    {
        if (_minTimerBetweenJumps <= _currentTimerBetweenJumps && _currentNumberOfJumps < _maxNumbOFJump && IsGrounded)
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