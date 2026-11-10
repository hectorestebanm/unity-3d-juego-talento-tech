using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Al estar encima de la plataforma comienza a caer hasta el suelo, y se resetea después de un segundo
public class Plataforma2 : MonoBehaviour
{
    //rotacion y posicion
    private Vector3 initialPos;
    private Quaternion initialRot;

    //tiempo pa que se destruya
    [SerializeField] private float timeToDestroy = 2f;
    private Rigidbody rb;

    //tiempo que permanece abajo
    [SerializeField] float dropDownTime = 1f;
    private void Start()
    {
        //Guardo pos y rotation para reseteo
        initialPos = transform.position;
        initialRot = transform.rotation;

        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        //Freezamos la posicion en z y x para que no se mueva al caer
        rb.constraints = RigidbodyConstraints.FreezePositionZ |
        RigidbodyConstraints.FreezePositionX;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Heroe"))
        {
            // Obtener la posición del jugador y la plataforma
            Vector3 playerPosition = other.transform.position;
            Vector3 platformPosition = transform.position;
            // Verificar si el jugador está por encima de la plataforma
            if (playerPosition.y > platformPosition.y)
            {

                //Sacamos el kinematic para que le afecten las fisicas
                rb.isKinematic = false;
                //llamamos a la corutina (cooldown) para el reseteo
                StartCoroutine(CoolDownDrop());
                // Destroy(gameObject, timeToDestroy);
                Debug.Log("El jugador está encima de la plataforma.");
            }
        }
    }

    //Corrutina: una función se ejecuta de principio a fin en el mismo momento,
    //Sin romper/detener el flujo del script
    IEnumerator CoolDownDrop()
    {

        // Espera el tiempo de cooldown
        //yield return es lo que permite pausar la corrutina
        //"yield return" es "pausate"
        //luego se agrega el tiempo
        //en este caso creamos ua instancia 
        yield return new WaitForSeconds(dropDownTime);
        transform.position = initialPos;
        transform.rotation = initialRot;
        rb.isKinematic = true; // Finaliza el cooldown.
        Debug.Log("Cooldown terminado. Puedes usar la habilidad de nuevo.");
    }

}
