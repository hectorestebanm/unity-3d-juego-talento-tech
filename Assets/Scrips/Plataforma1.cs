using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// AL tocar la plataforma, se destruye dentro de dos segundos
public class Plataforma1 : MonoBehaviour
{
    [SerializeField] private float timeToDestroy = 2f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Heroe"))
        {
            Destroy(gameObject, timeToDestroy);
        }
    } //(Hacer que vuelva a aparecer. Llamar al padre para que use una funcion de desactivar al hijo y activarlo)
}
