﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Malo : MonoBehaviour
{

     public GameObject original;
    public Transform referencia;            //SI QUIERE DISPARAR A OTRO LADO SOLO CAMBIAR LA POSICION DE LA REFERENCIA
    private IEnumerator disparo;
    public float targetTime = 2.0f;
    bool bandera=true;

    
    void Start()
    {
        disparo=Disparar();
    }

    // Update is called once per frame
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
    }

    IEnumerator Disparar(){
        while(true){
            //Instanciar bala
            Instantiate(original,referencia.position,referencia.rotation);
            yield return new WaitForSeconds(.1f);
            StopCoroutine(disparo); 
        }
    }
}

