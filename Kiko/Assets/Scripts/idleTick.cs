using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleTick : MonoBehaviour
{
    public bool doLongIdleAnim;
    private float IdleTime = 0f;
    public void idleTickCount(){//This is called from the AIdle and CIdle Animation
        IdleTime = this.GetComponent<Animator>().GetFloat("IdleTime");
        if (IdleTime > 6.0f || !doLongIdleAnim ){
            this.GetComponent<Animator>().SetFloat("IdleTime", 0f);
        }else{
            float addedTime = Random.Range(0f,1f);
            this.GetComponent<Animator>().SetFloat("IdleTime", IdleTime + addedTime);
        }
    }
    public void countZero(){
        this.GetComponent<Animator>().SetFloat("IdleTime", 0f);
    }
}
