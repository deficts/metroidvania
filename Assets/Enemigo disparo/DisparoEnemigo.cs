using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{
    public GameObject original;
    public Transform referencia;
private IEnumerator disparo;
    // Start is called before the first frame update
    void Start()
    {
        disparo=Disparar();
    }

    // Update is called once per frame
    void Update()
    {
    
        if(Input.GetKeyDown(KeyCode.Space)){
            StartCoroutine(disparo);
        }
        if(Input.GetKeyUp(KeyCode.Space)){
            StopCoroutine(disparo);
        }
    }

    IEnumerator Disparar(){
        while(true){
            //Instanciar bala
            Instantiate(original,referencia.position,referencia.rotation);
            yield return new WaitForSeconds(0.2f);
            
        }
    }
}
