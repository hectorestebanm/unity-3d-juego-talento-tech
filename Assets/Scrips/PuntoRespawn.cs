using UnityEngine;

public class PuntoRespawn : MonoBehaviour
{
    [SerializeField] private Transform puntoDeRespawn;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if(rb != null)
            rb.linearVelocity = Vector3.zero;
        other.transform.position = puntoDeRespawn.position;
    }
}
