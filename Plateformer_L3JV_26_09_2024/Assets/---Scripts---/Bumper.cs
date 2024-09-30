using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class Bumper : MonoBehaviour
{
    [SerializeField] GameObject _thisGO;
    [SerializeField] Score _score;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            _thisGO.transform.DOComplete();
            _thisGO.transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0), 0.3f, 2, 0.3f);
            _score.AddScoreBumpers();
        }
    }
}