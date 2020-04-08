using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrullaje : MonoBehaviour
{
    public Nodos[] ruta;
    public float velocidad = 5;
    public float rangoValido;

    private int nodoActual;

        void Start()
    {
        nodoActual = 0;
        StartCoroutine(VerificarDestino());
    }


    void Update()
    {
        transform.LookAt(ruta[nodoActual].transform);
        transform.Translate(transform.forward * Time.deltaTime * velocidad, Space.World);
    }


    IEnumerator VerificarDestino(){

        // intención: verificar qué tan cerca está de su destino actual para ver si cambiamos rumbo
        while(true){

            float distancia = Vector3.Distance(transform.position, ruta[nodoActual].transform.position);

            if(distancia < rangoValido){

                nodoActual++;
                nodoActual %= ruta.Length;
            }

            yield return new WaitForSeconds(0.3f);
        }
    }
}
