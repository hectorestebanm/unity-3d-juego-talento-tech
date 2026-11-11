using UnityEngine;
using UnityEngine.InputSystem;

public class TestDamage : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current.kKey.wasPressedThisFrame)
        {
            GetComponent<Health>().TakeDamage(25f);
            Debug.Log("Vida restante: " + GetComponent<Health>().CurrentHealth);
        }
    }
}
