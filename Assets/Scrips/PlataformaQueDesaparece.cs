using System.Collections;
using UnityEngine;

public class PlataformaQueDesaparece : MonoBehaviour
{
    [SerializeField] private float timeToDestroy = 1f;
    [SerializeField] private float intensidadTemblor = 0.03f;

    private bool activada;

    private void OnCollisionEnter(Collision collision)
    {
        if (activada)
            return;
        if (!collision.gameObject.CompareTag("Player"))
            return;

        activada = true;
        StartCoroutine(DesaparecerRoutine());
    }

    private IEnumerator DesaparecerRoutine()
    {
        Vector3 posOriginal = transform.position;
        float t = 0f;

        while (t < timeToDestroy)
        {
            float x = Random.Range(-intensidadTemblor, intensidadTemblor);
            float z = Random.Range(-intensidadTemblor, intensidadTemblor);
            transform.position = posOriginal + new Vector3(x, 0f, z);

            t += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}