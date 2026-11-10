using UnityEngine;

public class PlataformaVertical : MonoBehaviour
{
    [SerializeField] private Transform puntoDestino;
    [SerializeField] private float speed = 3f;
    private bool activada = false;

    void Update()
    {
        if (activada)
        {
            transform.position = Vector3.MoveTowards(transform.position, puntoDestino.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!activada && collision.gameObject.CompareTag("Player"))
        {
            activada = true;
        }
    }
}
