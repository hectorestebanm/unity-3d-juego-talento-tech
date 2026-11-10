using UnityEngine;
using UnityEngine.InputSystem;

public class Jump2 : MonoBehaviour
{
    public float jumpForce = 200f;
    public float rayLength = 1.1f;
    private Rigidbody rb;
    private InputAction jump;
    private Animator animator;
    private float jumpGraceTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = InputSystem.actions.FindAction("Jump");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //bool isGrounded = Physics.Raycast(transform.position, Vector3.down, rayLength);
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, rayLength, ~0, QueryTriggerInteraction.Ignore);
        Debug.DrawRay(transform.position, Vector3.down * rayLength, Color.red);
        
        // Solo puede saltar si está en el suelo y todavía puede saltar
        if(isGrounded && jump.WasPressedThisFrame())
        {
            Jumping();
            animator.SetBool("jumpHeroe", true);
            jumpGraceTimer = 0.2f;  // Ignora el suelo un instante después de saltar
        }
        jumpGraceTimer -= Time.deltaTime;
        if(jumpGraceTimer <= 0f)
        {
            animator.SetBool("jumpHeroe", !isGrounded);
        }
    }

    void Jumping()
    {
        rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
    }

}
