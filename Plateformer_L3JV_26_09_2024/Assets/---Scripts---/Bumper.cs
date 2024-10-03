using UnityEngine;
using DG.Tweening;

public class Bumper : MonoBehaviour
{
    [SerializeField] GameObject _thisGO;
    [Header("Score")]
    [SerializeField] Score _score;
    [SerializeField] float _maxTimerBetweenGetScore;
    [Header("Sounds")]
    [SerializeField] AudioClip _sound;
    [Header("Sprite changes")]
    [SerializeField] Sprite _spriteWhenTouched;
    [SerializeField] float _maxTimerChangeSprite;

    private float _currentTimerBetweenGetScore;
    private float _currentTimerChangeSprite;
    private bool _canTimer;
    private bool _canTimerSprite;
    private Sprite _baseSprite;

    private void Awake()
    {
        _baseSprite = GetComponent<SpriteRenderer>().sprite;
    }
    private void Start()
    {
        _canTimer = false;
        _canTimerSprite = false;
    }
    private void Update()
    {
        CheckTimerScore();
        CheckTimerSprite();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            _thisGO.transform.DOComplete();
            _thisGO.transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0), 0.3f, 2, 0.3f);
            if (!_canTimer)
            {
                _score.AddScoreBumpers();

                _score.GetSound(_sound);
                _score.PlaySound();
                gameObject.GetComponent<SpriteRenderer>().sprite = _spriteWhenTouched;

                _currentTimerChangeSprite = 0;
                _canTimerSprite = true;
                _canTimer = true;
            }
        }
    }
    private void CheckTimerScore()
    {
        if (_canTimer)
        {
            _currentTimerBetweenGetScore += Time.deltaTime;
            if (_currentTimerBetweenGetScore > _maxTimerBetweenGetScore)
            {
                _currentTimerBetweenGetScore = 0;
                _canTimer = false;
            }
        }
    }
    private void CheckTimerSprite()
    {
        if (_canTimerSprite)
        {
            _currentTimerChangeSprite += Time.deltaTime;
            if (_currentTimerChangeSprite >= _maxTimerChangeSprite)
            {
                GetComponent<SpriteRenderer>().sprite = _baseSprite;
            }
        }
    }
}