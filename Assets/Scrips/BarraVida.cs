using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    [SerializeField] private Image relleno;
    private Transform cam;

    void Start()
    {
        cam = Camera.main.transform;
    }

    public void Actualizar(float valor)
    {
        relleno.fillAmount = valor;
    }

    void LateUpdate()
    {
        transform.forward = cam.forward;
    }
}