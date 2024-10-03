using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveFakeBallSpawner : MonoBehaviour
{
    [SerializeField] GameObject _spawnerFakeBall;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            _spawnerFakeBall.SetActive(true);
        }
    }
}