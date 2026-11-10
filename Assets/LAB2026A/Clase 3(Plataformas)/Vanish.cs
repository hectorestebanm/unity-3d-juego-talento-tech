using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vanish : MonoBehaviour
{
    [SerializeField]
    private float timeToDestroy = 2f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject, timeToDestroy);
        }
    } //(Hacer que vuelva a aparecer. Llamar al padre para que use una funcion de desactivar al hijo y activarlo)
}
