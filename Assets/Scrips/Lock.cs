using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lock : MonoBehaviour
{
    // Lock Player a la plataforma
    private bool lockPlayer;
    private Transform player;

    void Start()
    {
        lockPlayer = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Si toco al jugador y "lockPlayer" es false, obtengo el componente y
        //pongo "lockPlayer" como true
        if (!lockPlayer && other.gameObject.CompareTag("Heroe"))
        {
            Debug.Log("Locked");
            player = other.gameObject.GetComponent<Transform>();
            player.transform.SetParent(gameObject.transform, true);
            lockPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (lockPlayer && other.gameObject.CompareTag("Heroe"))
        {
            Debug.Log("UnLocked");

            gameObject.transform.DetachChildren();

            lockPlayer = false;
        }
    }


}
