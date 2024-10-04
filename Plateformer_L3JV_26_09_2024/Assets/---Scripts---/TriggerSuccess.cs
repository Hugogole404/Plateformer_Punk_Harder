using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSuccess : MonoBehaviour
{
    [SerializeField] GameObject _victoryScreen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            _victoryScreen.SetActive(true);
        }
    }
}
