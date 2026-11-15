using UnityEngine;
using UnityEngine.InputSystem;

public class AtaqueJugador : MonoBehaviour
{
    [SerializeField] private float daño = 25f;
    [SerializeField] private float alcance = 1.5f;     // radio del golpe
    [SerializeField] private float distanciaFrente = 1f; // qué tan adelante del jugador
    [SerializeField] private float cooldown = 0.5f;    // tiempo entre golpes
    [SerializeField] private LayerMask capasGolpeables = ~0;

    private InputAction attack;
    private Animator animator;
    private float proximoAtaque;

    void Start()
    {
        attack = InputSystem.actions.FindAction("Attack");
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (attack.WasPressedThisFrame() && Time.time >= proximoAtaque)
        {
            proximoAtaque = Time.time + cooldown;
            Atacar();
        }
    }

    void Atacar()
    {
        // Cuando tengas la animación, creá un Trigger "atacar" en el Animator y descomentá:
        // animator.SetTrigger("atacar");

        Vector3 centro = transform.position + transform.forward * distanciaFrente;
        Collider[] golpeados = Physics.OverlapSphere(centro, alcance, capasGolpeables);

        foreach (Collider col in golpeados)
        {
            if (!col.CompareTag("Enemy")) continue;

            Health vida = col.GetComponentInParent<Health>();
            if (vida != null)
            {
                vida.TakeDamage(daño);
                Debug.Log("Golpeé a " + col.name + ". Vida restante: " + vida.CurrentHealth);
            }
        }
    }

    // Dibuja el área del golpe en la Scene para ajustarla
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + transform.forward * distanciaFrente, alcance);
    }
}