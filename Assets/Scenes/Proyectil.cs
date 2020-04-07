using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{

    
    Rigidbody2D rb;

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up*11,ForceMode2D.Impulse);
        Destroy(gameObject,3);

    }

    
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag=="PLAYER"){
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }
}
