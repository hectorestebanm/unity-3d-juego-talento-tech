using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlatform : MonoBehaviour
{
    private Transform posA;
    private Transform posB;
    private Transform platMove;
    private Transform currentTarget;
    [SerializeField] private float speed = 10f;
   // private Rigidbody rb;
    void Start()
    {
      
        platMove = transform.GetChild(0);
        posA = transform.GetChild(1);
        posB = transform.GetChild(2);
       // rb= platMove.GetComponent<Rigidbody>();
        currentTarget = posA;
    }
    void Update()
    {
        Movimiento();
    }
    private void Movimiento()
    {
        // Calcula la distancia hacia el objetivo actual
        float distance = Vector3.Distance(platMove.transform.position,
       currentTarget.position);
       // Debug.Log(distance);
        // Si está cerca del objetivo, cambia al otro punto
        if (distance < 0.1f)
        {
            if (currentTarget == posA)
            {
                currentTarget = posB;
            }
            else
            {
                currentTarget = posA;
            }
        }
        // Mueve la plataforma hacia el objetivo actual
        Vector3 direction = (currentTarget.position -
       platMove.transform.position).normalized;
      //  rb.velocity = direction * speed;
        platMove.transform.Translate(direction * speed * Time.deltaTime);
    }
}
