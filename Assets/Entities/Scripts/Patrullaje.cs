using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrullaje : MonoBehaviour
{
    public float velocidad;
    private float tiempoDeEspera;
    public float inicioTiempoDeEspera;

    public Transform[] nodos;
    private int nodoRandom;

    void Start()
    {
        tiempoDeEspera = inicioTiempoDeEspera;
        nodoRandom = Random.Range(0, nodos.Length);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, nodos[nodoRandom].position, velocidad * Time.deltaTime);

        if (Vector2.Distance(transform.position, nodos[nodoRandom].position) < 0.2f)
        {
            if (tiempoDeEspera <= 0)
            {
                tiempoDeEspera = inicioTiempoDeEspera;
                nodoRandom = Random.Range(0, nodos.Length);
            }
            else
            {
                tiempoDeEspera -= Time.deltaTime;
            }
        }

    }
}
