using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPlayerDrop : MonoBehaviour
{
    // Lock Player a la plataforma
    private bool lockPlayer;
    private Transform player;
    [SerializeField] private DropMovUp dmu;
    void Start()
    {
        lockPlayer = false;
    }
    void Update()
    {
      
    }
  



    private void OnTriggerEnter(Collider other)
    {
        //Si toco al jugador y "lockPlayer" es false, obtengo el componente y
        //pongo "lockPlayer" como true
        if (!lockPlayer && other.gameObject.CompareTag("Player"))
        {
            //lockea al jugador y lo convierte en hijo de la plataforma
            Debug.Log("Player Locked");
            player = other.gameObject.GetComponent<Transform>();
            player.transform.SetParent(gameObject.transform, true);
            lockPlayer = true;

            //Desbloquea la plataforma para que se mueva y asigna direccion (arriba)
            dmu.Switch(false,1);//Funcion del Script "DropMovUp"
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Desbloquea al jugador y lo saca de la plataforma
        if (lockPlayer && other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player UnLocked");
            
            gameObject.transform.DetachChildren();
            // player.transform.parent = null;
            lockPlayer = false;

            //Desbloquea la plataforma para que se mueva y asigna direccion (bajo)
            dmu.Switch(false,2);
        }
    }
}
