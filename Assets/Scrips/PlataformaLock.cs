using UnityEngine;

public class PlataformaLock : MonoBehaviour
{
    // Lock Player a la plataforma
    private bool lockPlayer;
    private Transform player;
    private Vector3 lastPosition;
    void Start()
    {
        lockPlayer = false;
        lastPosition = transform.position;
    }

    void Update()
    {
        PlayerLock();
        lastPosition = transform.position;
    }

    private void PlayerLock()
    {
        //Si el player esta lockeado y la variable NO es null, lo muevo junto con la plataforma
        if (lockPlayer && player != null)
        {
            Vector3 delta = transform.position - lastPosition;
            player.position += delta;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Si toco al jugador y "lockPlayer" es false, obtengo el componente y pongo "lockPlayer" como true
        if (!lockPlayer && collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Locked");
            player = collision.transform;
            lockPlayer = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (lockPlayer && collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("UnLocked");
            player = null;
            lockPlayer = false;
        }
    }
}