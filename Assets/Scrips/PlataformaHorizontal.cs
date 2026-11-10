using UnityEngine;

public class PlataformaHorizontal : MonoBehaviour
{
    private Transform pointA;
    private Transform pointB;
    private Transform platHoriz;
    private Transform currentTarget;
    [SerializeField] private float speed = 10f;

    void Start()
    {
        platHoriz = transform.GetChild(0);
        pointA = transform.GetChild(1);
        pointB = transform.GetChild(2);
        currentTarget = pointA;
    }

    void Update()
    {
        Movimiento();
    }

    private void Movimiento()
    {
        // Calcula la distancia hacia el objetivo actual
        float distance = Vector3.Distance(platHoriz.transform.position, currentTarget.position);
        // Si está cerca del objetivo, cambia al otro punto
        if (distance < 0.1f)
        {
            if (currentTarget == pointA)
            {
                currentTarget = pointB;
            }
            else
            {
                currentTarget = pointA;
            }
        }
        // Mueve la plataforma hacia el objetivo actual
        Vector3 direction = (currentTarget.position - platHoriz.transform.position).normalized;
        platHoriz.transform.Translate(direction * speed * Time.deltaTime);
    }
}