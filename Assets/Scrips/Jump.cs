using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    public float jumpForce = 200f;
    public float rayLength = 1.1f;
    private Rigidbody rb;
    private InputAction jump;
    private bool canJump = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, rayLength);
        Debug.DrawRay(transform.position, Vector3.down * rayLength, Color.red);
        // Si esta en el suelo, vuelve a permitir el salto
        if(isGrounded)
        {
            canJump = true;
        }
        // Solo puede saltar si está en el suelo y todavía puede saltar
        if(isGrounded && canJump && jump.WasPressedThisFrame())
        {
            Jumping();
            canJump = false;
        }
    }

    void Jumping()
    {
        //rb.AddForce(0, jumpForce, 0);
        rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
    }

}
