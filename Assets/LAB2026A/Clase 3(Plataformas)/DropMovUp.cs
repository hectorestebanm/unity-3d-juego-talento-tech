using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMovUp : MonoBehaviour
{
    //[SerializeField] private float timeToDestroy = 2f;
    private Rigidbody rb;
    private Transform posA;
    private Transform posB;
    private Transform platMove;
    private Transform currentTarget;
    [SerializeField] private float speed = 10f;
    private bool _locked;
    private bool permanentLocked;

    public bool locked
    {
        get
        {
            return _locked; 
        }

        private set { _locked = value; }
    }
    void Start()
    {
        platMove = transform.GetChild(0);
        posA = transform.GetChild(1);
        posB = transform.GetChild(2);
        
        currentTarget = posA;
    }

    void Update()
    {
        Movimiento();
    }

    //La diferencia de este script de plataforma movible es que la direccion
    //no cambia al llegar al punto, sino al subirme o bajarme de ella

    public void Switch(bool b, int n)
    {//Funcion que cambia el lock de la plataforma y segun posicion enviada, cambia direccion
        locked = b;
        if (n == 1)
        {//Si se sube, enviaremos un 1 para que cambie direccion y vaya para arriba
            currentTarget = posB;
        }
        else if (n == 2)
        {//Si se baja, enviaremos un 2 para que cambie direccon y baje
            currentTarget = posA;
        //Recordemos que en la funcion "movimiento" al llegar a la pos A, lockea para que no siga bajando

        }
        

    }
    private void Movimiento()
    {
        //Para moverme tengo que estar desbloqueado
        if (!locked && !permanentLocked){
            // Calcula la distancia hacia el objetivo actual
            float distance = Vector3.Distance(platMove.transform.position,
           currentTarget.position);
            if (distance < 0.1f && currentTarget == posB){
                //Si llego a la posicion deseada (posB), lockea permanentemente
                permanentLocked = true;
               // locked = true;
                // Si está cerca del objetivo A, Hace un lock temporal
            }
            else if (distance < 0.1f && currentTarget == posA){
                locked = true;
            }
            // Mueve la plataforma hacia el objetivo actual
            Vector3 direction = (currentTarget.position -
           platMove.transform.position).normalized;
        

            platMove.transform.Translate(direction * speed * Time.deltaTime);
        }
      
    }

    //StartCoroutine(CoolDown())
    /*IEnumerator CoolDown()
    {

        // Espera el tiempo de cooldown
        yield return new WaitForSeconds(2f);
        locked = false;
        
    }*/






      

}
