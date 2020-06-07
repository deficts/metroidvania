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


    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    private void Update()
    {

        if (vida <= 25) {
            anim.SetTrigger("stageTwo");
            ChangeSprite();
        }

        if (vida <= 0) {
            anim.SetTrigger("death");
        }

        // Para que se recupere un poco antes de recibbir más daño
        if (timeDamage > 0) {
            timeDamage -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
         if (collision.gameObject.CompareTag("Player"))
        {
            //MECANISMO DE VIDA
            vida -= 1;
            timeDamage = 1f;
        }
    }

    void ChangeSprite()
    {
        spriteRenderer.sprite = stageTwo; 
    }
}
