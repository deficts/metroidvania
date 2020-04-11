using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public GameObject attackTrigger;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetBool("IsAttacking", true);
            attackTrigger.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            animator.SetBool("IsAttacking", false);
            attackTrigger.SetActive(false);

        }
    }
}
