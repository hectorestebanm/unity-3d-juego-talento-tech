using UnityEngine;

public class CamaraTerceraPersona : MonoBehaviour
{
    public Transform target; // Tu personaje (Heroe)
    public Vector3 offset = new Vector3(0, 3f, -5f); // Posición relativa detrás y arriba
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        // Posición deseada: la del personaje + el offset rotado según su orientación
        //Vector3 posicionDeseada = target.position + target.TransformDirection(offset);
        Vector3 posicionDeseada = target.position + offset;

        // Suaviza el movimiento de la cámara hacia esa posición
        transform.position = Vector3.Lerp(transform.position, posicionDeseada, smoothSpeed * Time.deltaTime);

        // La cámara siempre mira hacia el personaje (un poco más arriba, a la altura de la cabeza)
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}