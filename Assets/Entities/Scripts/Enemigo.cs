using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{

    public GameObject proyectil;
    public Transform referencia;            //SI QUIERE DISPARAR A OTRO LADO SOLO CAMBIAR LA POSICION DE LA REFERENCIA
    private IEnumerator disparo;
    public float targetTime = 2.0f;
    bool bandera=true;
    public int life = 3;

    
    void Start()
    {
        disparo=Disparar();
    }
    void Update()
    {
       targetTime = targetTime-Time.deltaTime; 
       if (targetTime <= 0.0f)
        {   
            bandera=false;
            StartCoroutine(disparo); 
            if(bandera==false){
               targetTime = 2.0f; 
            }
            
        }
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Disparar(){
        while(true){
            //Instanciar bala
            Instantiate(proyectil,referencia.position,referencia.rotation);
            yield return new WaitForSeconds(.1f);
            StopCoroutine(disparo); 
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("golpe");
        if (collision.gameObject.CompareTag("ProyectilPerrito"))
        {
            life -= 1;
        }
    }
}

