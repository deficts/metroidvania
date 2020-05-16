using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public GameObject attackTrigger;
    Animator animator;

    public AudioSource playerAudio;
    public AudioClip[] clips;


    void Start()
    {
        animator = GetComponent<Animator>();
        playerAudio=GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetBool("IsAttacking", true);
            attackTrigger.SetActive(true);
            playerAudio.clip=clips[0];
            playerAudio.Play();
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            animator.SetBool("IsAttacking", false);
            attackTrigger.SetActive(false);

        }
    }
}
