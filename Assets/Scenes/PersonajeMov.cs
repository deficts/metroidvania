using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonajeMov : MonoBehaviour
{
    //private Animator animator;  //ANIMACION DEL PERSONAJE
    Rigidbody2D rb;
    float dirX, moveSpeed=5f;
    public Text texto;
    public int puntuacion = 100;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        texto.text = "VIDA: "+puntuacion;
        //animator = GetComponent<Animator>();   PARA ANIMACION
    }

    void Update()
    {
        //MOVIMIENTO EN EJE X DE IZQUIERDA A DERECHA    CON ANIMACION 
        //float h = Input.GetAxis("Horizontal");
        //float velocidad = h * 5 * Time.deltaTime;
        //transform.Translate(velocidad,0,0);
        //animator.SetFloat("velocidad",velocidad);

        dirX=Input.GetAxis("Horizontal")*moveSpeed;                 //MOVIMIENTO EN 2 DIRECCIONES

        if(Input.GetButtonDown("Jump")&&rb.velocity.y==0)           //SALTO 
            rb.AddForce(Vector2.up*150f);

        mecanismoVida(puntuacion);              //SIEMPRE LO REVISA

    }

    public void FixedUpdate(){
        rb.velocity=new Vector2(dirX,rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision){                 //PERSONAJE SIGUE EL MOVIMIENTO DE LAS PLATAFORMAS
    if(collision.gameObject.tag=="Plataforma"){
        this.transform.parent=collision.transform;
     }

    if (collision.gameObject.tag == "Bala"){            //MECANISMO DE VIDA
        puntuacion = puntuacion -10 ;
    }

     if (collision.gameObject.tag == "Malo"){                   //MECANISMO DE VIDA
       puntuacion = puntuacion -50 ;
    }

        texto.text = "VIDA: "+puntuacion.ToString();
    }

    private void OnCollisionExit2D(Collision2D collision){
 
     if(collision.gameObject.tag=="Plataforma"){
        this.transform.parent=null;
        }
    }

    public void mecanismoVida(int puntuacion){          //SE DETIENE EL JUEGO 
        if(puntuacion<=0){
            Time.timeScale = 0;
        }
    }


}
