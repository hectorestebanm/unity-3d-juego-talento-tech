using UnityEngine;
using UnityEngine.InputSystem;

// Este script debe ir dentro del Main Camera
public class CamThird : MonoBehaviour
{
    private Transform p; // Referencia al jugador

    public float sensitivity = 2f;
    public float distance = 5f;

    private float xRotation = 20f;
    private float yRotation = 0f;


    void Start()
    {
        // Encuentro el objeto con el tag Player
        p = GameObject.FindWithTag("Heroe").GetComponent<Transform>();

        // Bloqueo el cursor
        Cursor.lockState = CursorLockMode.Locked;
    }


    // Usamos LateUpdate porque queremos mover la cámara
    // después de que el jugador terminó de moverse
    void LateUpdate()
    {
        // Obtengo el movimiento del mouse
        // delta representa cuánto se movió el mouse
        Vector2 mouseInput = Mouse.current.delta.ReadValue();


        // ----- ROTACIÓN VERTICAL -----

        // Obtengo el movimiento vertical del mouse
        xRotation -= mouseInput.y * sensitivity;

        // Limito cuánto puede mirar hacia arriba y abajo
        xRotation = Mathf.Clamp(xRotation, 0f, 40f);



        // ----- ROTACIÓN HORIZONTAL (Jugador)-----

        // Rotamos el jugador horizontalmente
        p.Rotate(Vector3.up * mouseInput.x * sensitivity);

        // También guardamos esa rotación para calcular
        // dónde debe posicionarse la cámara
        yRotation = p.eulerAngles.y;



        // ----- ROTACIÓN DE LA CÁMARA -----

        // Creamos una rotación utilizando los ángulos X e Y
        Quaternion rotation = Quaternion.Euler(xRotation, yRotation, 0f);


        // Calculamos una posición detrás del jugador
        Vector3 position = p.position - rotation * Vector3.forward * distance;

        // Movemos la cámara a esa posición
        transform.position = position;


        // Hacemos que la cámara mire hacia el jugador
        transform.LookAt(p);
    }
}