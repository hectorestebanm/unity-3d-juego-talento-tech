using UnityEngine;
using UnityEngine.InputSystem;

public class Mov : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 input;
    public float moveSpeed = 5f;
    private float ogSpeed;
    [SerializeField] private float multSpeed;
    [SerializeField] private float valMultSpeed = 1.5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Se debe agregar un Rigidbody para que tenga la física de movimiento 
        rb = GetComponent<Rigidbody>();
        ogSpeed = moveSpeed;
        multSpeed = moveSpeed * valMultSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        input = InputSystem.actions.FindAction("Move").ReadValue<Vector2>();
        if(InputSystem.actions.FindAction("Sprint").IsPressed())
        {
            moveSpeed = multSpeed;
        }
        else
        {
            moveSpeed = ogSpeed;
        }
        //Debug.Log(rb.linearVelocity);
    }

    void FixedUpdate()
    {
        // Convertir Vector2 a Vector3
        Vector3 movement = new Vector3(input.x, 0, input.y);
        movement = movement.normalized;
        // Movimiento según la dirección del jugador dentro del juego, no la del mundo real
        movement = transform.TransformDirection(movement);
        // Aplicar velocidad al Rigidbody
        rb.linearVelocity = new Vector3(movement.x * moveSpeed, rb.linearVelocity.y, movement.z * moveSpeed);
    }

}
