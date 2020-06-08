using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
   public int vida=100;
    private float timeDamage = 1.5f;

    
    private Animator anim;
    private bool isDead;

    public SpriteRenderer spriteRenderer;
    public Sprite stageTwo;

    public Transform playerPos;
    public int speed;
    public int speed2;

    public Transform referencia;
    public GameObject proyectil;
    public float targetTime = 2.0f;
    private bool disparar;
    private IEnumerator disparo;
    bool bandera = true;
    public GameObject portal;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        disparo = Disparar();
    }

    private void Update()
    {
        targetTime = targetTime - Time.deltaTime;
        if (vida <= 50.0f) {
            anim.SetTrigger("stageTwo");
        }

        if (vida <= 0) {
            anim.SetTrigger("death");
            portal.SetActive(true);
            GetComponent<Boss>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Look>().enabled = false;
        }

        // Para que se recupere un poco antes de recibir más daño
        if (timeDamage > 0) {
            timeDamage -= Time.deltaTime;
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("jumpOne"))
        {
            Vector2 target = new Vector2(playerPos.position.x, transform.position.x+5);
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("idleOne"))
        {
            Vector2 target = new Vector2(transform.position.x, 1);
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("jumpTwo"))
        {
            disparar = true;
            Vector2 target = new Vector2(playerPos.position.x, transform.position.x + 5);
            transform.position = Vector2.MoveTowards(transform.position, target, speed2 * Time.deltaTime);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("idleTwo"))
        {

            Vector2 target = new Vector2(transform.position.x, 1);
            transform.position = Vector2.MoveTowards(transform.position, target, speed2 * Time.deltaTime);
        }


        if (disparar)
        {
            if (targetTime <= 0.0f)
            {
                bandera = false;
                StartCoroutine(disparo);
                if (bandera == false)
                {
                    targetTime = 2.0f;
                }

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
         if (collision.gameObject.CompareTag("Player"))
        {
            //MECANISMO DE VIDA
            vida -= 1;
            timeDamage = 1f;
        }
        if (collision.gameObject.CompareTag("ProyectilPerrito"))
        {
            vida -= 3;
            timeDamage = 1f;
        }
    }


    IEnumerator Disparar()
    {
        while (true)
        {
            //Instanciar bala
            Instantiate(proyectil, referencia.position, referencia.rotation);
            yield return new WaitForSeconds(.1f);
            StopCoroutine(disparo);
        }
    }
}