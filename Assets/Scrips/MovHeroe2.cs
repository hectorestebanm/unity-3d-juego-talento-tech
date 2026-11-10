using UnityEngine;
using UnityEngine.InputSystem;

public class MovHeroe2 : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 input;
    public float moveSpeed = 5f;
    private float ogSpeed;
    [SerializeField] private float multSpeed;
    [SerializeField] private float valMultSpeed = 1.5f;
    [SerializeField] private float rotationSpeed = 10f;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ogSpeed = moveSpeed;
        multSpeed = moveSpeed * valMultSpeed;
        animator = GetComponent<Animator>();
        animator.SetBool("walkHeroe", false);
    }

    void Update()
    {
        input = InputSystem.actions.FindAction("Move").ReadValue<Vector2>();
        if (InputSystem.actions.FindAction("Sprint").IsPressed())
        {
            moveSpeed = multSpeed;
        }
        else
        {
            moveSpeed = ogSpeed;
        }
    }

    void FixedUpdate()
    {
        // Movimiento en base a ejes del MUNDO, no de la orientación del personaje
        Vector3 movement = new Vector3(input.x, 0, input.y).normalized;

        rb.linearVelocity = new Vector3(movement.x * moveSpeed, rb.linearVelocity.y, movement.z * moveSpeed);

        // Rotar el personaje hacia la dirección en la que se mueve
        if (movement.magnitude > 0.1f)
        {
            Quaternion rotacionObjetivo = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo, rotationSpeed * Time.fixedDeltaTime);
        }

        // Solo mide velocidad horizontal, ignorando Y
        Vector3 velocidadHorizontal = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
        if (velocidadHorizontal.magnitude > 0.1f)
        {
            animator.SetBool("walkHeroe", true);
        }
        else
        {
            animator.SetBool("walkHeroe", false);
        }
    }
}