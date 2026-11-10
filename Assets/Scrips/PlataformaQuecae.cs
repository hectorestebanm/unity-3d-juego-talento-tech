using UnityEngine;
using System.Collections;
public class PlataformaQuecae : MonoBehaviour
{
    [SerializeField] private float timeToDestroy = 1f;
    [SerializeField] private float delayBeforeFall = 0.2f;
    private Rigidbody rb;
    //private bool activada;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(CaerConDelay());
        }
    }

    private IEnumerator CaerConDelay()
    {
        yield return new WaitForSeconds(delayBeforeFall);
        rb.isKinematic = false;
        Destroy(gameObject, timeToDestroy);
    }
}