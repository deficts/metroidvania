using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golpe : MonoBehaviour
{
    public float vida=100.0f;
    public GameObject player;
    public Transform referencia;

    // Start is called before the first frame update
    void Start()
    {
        Ataque();
    }

    // Update is called once per frame
    void Update()
    {
    
        if(Input.GetKeyDown(KeyCode.G)){
           Ataque();
        }
       
    }

    void Ataque(){
        if(Vector3.Distance(player.transform.position,transform.position)<0.3f){
            vida--;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Ataque();
    }
}
