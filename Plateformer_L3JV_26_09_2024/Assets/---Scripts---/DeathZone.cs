using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>() != null)
        {
            collision.GetComponent<PlayerController>().TeleportPlayerToSpawnPoint();
            collision.GetComponent<PlayerController>().ResetCurrentPlateform();
            _mainCamera.GetComponent<CameraScript>().RestartCamera();
        }
    }
}