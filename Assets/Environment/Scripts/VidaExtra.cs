using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaExtra : MonoBehaviour
{
    public PlayerManager player;
    public AudioSource ad;
    public AudioClip clip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(player.vida < 100)
            {
                if (player.vida + 50 >= 100)
                {
                    player.vida = 100;
                }
                else
                {
                    player.vida += 50;
                }
                ad.PlayOneShot(clip);
                Destroy(gameObject);
            }
        }
    }
}
