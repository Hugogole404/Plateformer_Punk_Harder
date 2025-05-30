using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Movements")]
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody;
    [Header("Jumps")]
    [SerializeField] private float _jumpForce;
    [SerializeField] private int _maxNumbOFJump;
    private float _currentNumberOfJumps;
    [SerializeField] private float _minTimerBetweenJumps;
    [SerializeField] private LayerMask _layerMask;
    [Header("Spawn Point")]
    public GameObject _spawnPoint;
    [Header("Gravity")]
    [SerializeField] private float _gravityMultiplier;
    [Header("Animator")]
    [SerializeField] private Animator _animator;
    [SerializeField] private float _maxSpeedIdle;
    [SerializeField] private float _maxSpeedWalk;
    [Header("Lock Control When Intro")]
    [SerializeField] private float _maxTimerLockControls;
    private float _currentTimerLockControls;
    [Header("Back menu")]
    [SerializeField] private string _sceneName;

    [HideInInspector] public bool IsGrounded;

    private float _gravity = -9.81f;
    private float _currentTimerBetweenJumps;
    private Vector2 _inputs;
    private Vector2 _direction = Vector2.zero;
    private bool _canJump;
    private Vector3 _offset;
    private Transform _toFollow;
    private PatternObject _currentPlatform;

    private void Start()
    {
        TeleportPlayerToSpawnPoint();
        _currentTimerBetweenJumps = 0;
        _animator.SetBool("IsBall", false);
        _animator.SetBool("IsBall", false);
        _animator.SetBool("TransitionBall", false);
    }
    private void Update()
    {
        _currentTimerBetweenJumps += Time.deltaTime;
        _currentTimerLockControls += Time.deltaTime;
        CheckSpeedForAnimator();
        CheckTimerLockControls();
    }
    private void FixedUpdate()
    {
        ApplyMovements();

        if (_currentPlatform != null)
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
        _inputs = context.ReadValue<Vector2>();
    }  
    public void EscapeMenu(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        SceneManager.LoadScene($"{_sceneName}");
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & _layerMask) != 0)
        {
            IsGrounded = true;
            _currentNumberOfJumps = 0;

            CheckJumpConditions();

            if (collision.gameObject.GetComponent<PatternObject>() != null)
            {
                _currentPlatform = collision.gameObject.GetComponent<PatternObject>();
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        ResetCurrentPlateform();
    }
    public void ResetCurrentPlateform()
    {
        _currentPlatform = null;
    }
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
    private void CheckSpeedForAnimator()
    {
        if (_rigidbody.velocity.magnitude > 0)
        {
            if (_rigidbody.velocity.magnitude < _maxSpeedIdle)
            {
                _animator.SetBool("IsWalking", false);
                _animator.SetBool("IsBall", false);
                _animator.SetBool("TransitionBall", false);
            }
            else if (_rigidbody.velocity.magnitude < _maxSpeedWalk)
            {
                _animator.SetBool("IsWalking", true);
                _animator.SetBool("IsBall", false);
                _animator.SetBool("TransitionBall", false);
            }
            else if (_rigidbody.velocity.magnitude > _maxSpeedWalk)
            {
                _animator.SetBool("IsBall", true);
                _animator.SetBool("IsWalking", false);
                _animator.SetBool("TransitionBall", false);
            }
        }
    }
    private void CheckTimerLockControls()
    {
        if (_currentTimerLockControls <= _maxTimerLockControls)
        {
            _rigidbody.transform.position = _spawnPoint.transform.position;
            _rigidbody.freezeRotation = true;
        }
        else
        {
            _rigidbody.freezeRotation = false;
        }
    }
}