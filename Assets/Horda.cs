using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horda : MonoBehaviour
{
    public List<GameObject> enemigos;
    public GameObject puertas;


    void Update()
    {
        CheckEnemigos();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            puertas.SetActive(true);
            ActivarEnemigos();
        }
    }

    private void ActivarEnemigos()
    {
        for (int i = 0; i < enemigos.Count; i++)
        {
            enemigos[i].SetActive(true);
        }
    }
    private void CheckEnemigos()
    {
        for(int i=0; i<enemigos.Count; i++){
            if (enemigos[i] == null)
            {
                enemigos.RemoveAt(i);
            }
        }
        if (enemigos.Count == 0)
        {
            puertas.SetActive(false);
        }
    }
}
