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
    [Header("Jumps")]
    [SerializeField] private KeyCode _keyJump;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _numberOfJumps;
    [SerializeField] private float _minTimerBetweenJumps;
    [Header("Spawn Point")]
    [SerializeField] private GameObject _spawnPoint;
    [Header("Gravity")]
    [SerializeField] private float _gravityMultiplier;

    private float _gravity = -9.81f;
    Vector2 _inputs;
    bool _inputJump;
    Vector2 _direction = Vector2.zero;

    private void Start()
    {
        TeleportPlayerToSpawnPoint();
    }
    private void Update()
    {

    }

    public void TeleportPlayerToSpawnPoint()
    {
        transform.position = _spawnPoint.transform.position;
    }
    public void Move(InputAction.CallbackContext context)
    {
        _inputs = context.ReadValue<Vector2>();
        _direction = new Vector3(_inputs.x, _inputs.y);
    }
    private void Movements()
    {
        _inputs.x = Input.GetAxisRaw("Horizontal");
        _inputs.y = Input.GetAxisRaw("Vertical");

        _inputJump = Input.GetKey(KeyCode.Space);
    }
}