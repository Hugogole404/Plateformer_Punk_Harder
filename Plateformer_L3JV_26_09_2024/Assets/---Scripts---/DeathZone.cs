using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;
    [SerializeField] Score _score;
    [SerializeField] private TimeScript _timeScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            player.TeleportPlayerToSpawnPoint();
            player.ResetCurrentPlateform();
            _mainCamera.GetComponent<CameraScript>().RestartCamera(player);
            _score.ReinitScore();
            //DeathCounterAdd();
        }
    }
    private void DeathCounterAdd()
    {
        _timeScript.DeathCount +=1;
    }
}