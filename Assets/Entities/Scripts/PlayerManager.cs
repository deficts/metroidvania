using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    //private Animator animator;  //ANIMACION DEL PERSONAJE
    private Rigidbody2D rb;
    private float dirX;
    public float moveSpeed=5f;
    public Text texto;
    public int vida = 100;
    private Animator animator;
    [SerializeField] LayerMask platformLayer;
    public Image damage;
    public float flash=10f;
    public Color fColor=new Color(1f,0f,0f,0.1f);
    bool damaged;


    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        texto.text = "VIDA: "+vida;
        animator = GetComponent<Animator>();
        damage.color=Color.clear;

    }

    void Update()
    {

        dirX=Input.GetAxis("Horizontal")*moveSpeed;                 //MOVIMIENTO EN 2 DIRECCIONES
        float velocidad = Mathf.Abs(dirX*Time.deltaTime);
        animator.SetFloat("Velocidad", velocidad);
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(Vector2.up * 250);
            animator.SetBool("IsJumping", true);
        }
        MecanismoVida(vida);              //SIEMPRE LO REVISA
        TurnPlayer();

        if(damaged){
            damage.color=fColor;
        }else{
            damage.color=Color.Lerp(damage.color,Color.clear,flash*Time.deltaTime);
        }
        damaged=false;
    }

    public void FixedUpdate(){
        rb.velocity=new Vector2(dirX,rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision){                 //PERSONAJE SIGUE EL MOVIMIENTO DE LAS PLATAFORMAS
        if(collision.gameObject.CompareTag("Plataforma"))
        {
            animator.SetBool("IsJumping", false);
            this.transform.parent=collision.transform;
        }

        if (collision.gameObject.CompareTag("Proyectil"))
        {
            //MECANISMO DE VIDA
            vida -= 10 ;
            damageTime = 1f;
        }

        if (collision.gameObject.CompareTag("Enemigo"))
        {
            //MECANISMO DE VIDA
            vida -= 20;
            damageTime = 1f;
        }

        if (collision.gameObject.CompareTag("Suelo"))
        {
            animator.SetBool("IsJumping", false);
        }
        texto.text = "VIDA: "+vida.ToString();

    }

    private void OnCollisionExit2D(Collision2D collision){

     if(collision.gameObject.CompareTag("Plataforma"))
        {
        this.transform.parent=null;
        }
    }

    public void MecanismoVida(int puntuacion){          //SE DETIENE EL JUEGO
        if(puntuacion<=0){
            Time.timeScale = 0;
        }
    }

    private bool IsGrounded()
    {
        float height = 1f;
        CapsuleCollider2D cc = GetComponent<CapsuleCollider2D>();
        RaycastHit2D raycastHit = Physics2D.BoxCast(cc.bounds.center, cc.bounds.size, 0f, Vector2.down, height, platformLayer);
        return (raycastHit.collider != null);
    }

    private void TurnPlayer()
    {
        if (dirX>0)
        {
            transform.rotation= new Quaternion(transform.rotation.x/2, 0, transform.rotation.z/2,0);
        }else if (dirX < 0)
        {
            transform.rotation = new Quaternion(transform.rotation.x/2, 180, transform.rotation.z/2,0);
        }
    }

}
