using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    //private Animator animator;  //ANIMACION DEL PERSONAJE
    private Rigidbody2D rb;
    private float dirX;
    public float moveSpeed=5f;
    //public Text texto;
    public int vida = 100;
    private Animator animator;
    [SerializeField] LayerMask platformLayer;
    public Image damage;
    public Color damageColor=new Color(1f,0f,0f,0.1f);
    public float flashTime;
    private float damageTime = -1.0f;
    private int b=3;
    private Menu objeto;
    public GameObject botella;
    public bool jumpPowerUp= true;
    private bool doubleJump;
    public bool invencible;

    static public int botellas=0;
    private float invincibilityTime=10;

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        //texto.text = "VIDA: "+vida;
        animator = GetComponent<Animator>();
        StartCoroutine(ReceiveDamage());
        
        botella=GameObject.Find("SpriteBotella");
    }

    void Update()
    {
        dirX =Input.GetAxis("Horizontal")*moveSpeed;                 //MOVIMIENTO EN 2 DIRECCIONES
        float velocidad = Mathf.Abs(dirX*Time.deltaTime);
        animator.SetFloat("Velocidad", velocidad);
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded())
            {
                rb.AddForce(Vector2.up * 250);
                animator.SetBool("IsJumping", true);
                if (jumpPowerUp)
                {
                    doubleJump = true;
                }
            }
            else
            {
                if (doubleJump)
                {
                    rb.AddForce(Vector2.up * 250);
                    animator.SetBool("IsJumping", true);
                    doubleJump = false;
                }
            }
        }
        MecanismoVida(vida);              //SIEMPRE LO REVISA
        TurnPlayer();
    }

    public void FixedUpdate(){
        rb.velocity=new Vector2(dirX,rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        //PERSONAJE SIGUE EL MOVIMIENTO DE LAS PLATAFORMAS
        if(collision.gameObject.CompareTag("Plataforma"))
        {  
            this.transform.parent=collision.transform;
        }

        if (IsGrounded())
        {
            animator.SetBool("IsJumping", false);
        }

        if (collision.gameObject.tag == "Botella")
        {
            botellas += 1;
            print(botellas);
            Destroy(collision.gameObject);
            b--;
            botella.SendMessage("cambioBotella",b);
            
        }

        if (!invencible)
        {
            if (collision.gameObject.tag == "Invencible")
            {
                Destroy(collision.gameObject);
                StartCoroutine(Invencibilidad());
            }
            if (collision.gameObject.CompareTag("Proyectil"))
            {
                //MECANISMO DE VIDA
                vida -= 5;
                damageTime = 1f;
            }

            if (collision.gameObject.CompareTag("Enemigo"))
            {
                //MECANISMO DE VIDA
                vida -= 5;
                damageTime = 1f;
            }
            if (collision.gameObject.CompareTag("Boss"))
            {
                //MECANISMO DE VIDA
                vida -= 5;
                damageTime = 1f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PowerUpDisparo")
        {
            GetComponent<DisparoPerrito>().enabled = true;
            AudioSource audio = collision.gameObject.GetComponent<AudioSource>();
            audio.PlayOneShot(audio.clip);
            Destroy(collision.gameObject, 0.1f);
        }
        if(collision.gameObject.name == "PowerUpSalto")
        {
            this.jumpPowerUp = true;
            AudioSource audio = collision.gameObject.GetComponent<AudioSource>();
            audio.PlayOneShot(audio.clip);
            Destroy(collision.gameObject, 0.1f);
        }

        if (!invencible)
        {
            if (collision.gameObject.name == "Invencible")
            {
                Destroy(collision.gameObject, 0.1f);
                StartCoroutine(Invencibilidad());
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision){
 
    if(collision.gameObject.CompareTag("Plataforma")){
        this.transform.parent=null;
        }
    }

    public void MecanismoVida(int puntuacion){
        //SE DETIENE EL JUEGO 
        if(puntuacion<=0){
            if (botellas<6)
            {
                botellas = 0;
                SceneManager.LoadScene("Lose");
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
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

    IEnumerator ReceiveDamage()
    {
        while (true)
        {
            if (damageTime >= 0.0f)
            {
                damage.color = Color.Lerp(damageColor,Color.clear, Mathf.PingPong(Time.time, .5f));
                damageTime -= Time.deltaTime;
            }
            else
            {
                damage.color = Color.clear;
            }
            yield return null;
        }
    }

    IEnumerator Invencibilidad()
    {
        invencible = true;
        StartCoroutine(ColorInvencible());

        yield return new WaitForSeconds(invincibilityTime);
        GetComponent<SpriteRenderer>().color = Color.white;
        invencible = false;
    }

    IEnumerator ColorInvencible()
    {
        while (invencible)
        {
            Color targetColor = new Color(Random.value, Random.value, Random.value);
            GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, targetColor, Mathf.PingPong(Time.time, .5f));
            yield return new WaitForSeconds(.1f);
        }
    }
}
