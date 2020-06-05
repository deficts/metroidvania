﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introBehaviour : StateMachineBehaviour
{
    private int rand;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rand=Random.Range(0,2);
        if(rand==0){
            animator.SetTrigger("idleOne");
        }else{
            animator.SetTrigger("jumpOne" );
        }
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    
     override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    
}
