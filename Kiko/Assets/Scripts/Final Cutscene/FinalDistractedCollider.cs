using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class FinalDistractedCollider : MonoBehaviour
{
    public MovementControl moveControl;
    public DialogueRunner dRunner;
    public FinalTriggers finalTriggers;
    // Start is called before the first frame update
    void Start()
    {
        dRunner.AddCommandHandler("EnableMovement", startMovement); //enable movement from yarn script
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void startMovement()
    {
        moveControl.EnableMovement();
        Debug.Log("start move");
    }

    void OnTriggerEnter(Collider other) //if true, triggers dialogue
    {
        if (other.tag == "Player" && finalTriggers.hasTalkedTopher == false)
        {
        dRunner.StartDialogue("distractedTopher");
        moveControl.DisableMovement();
        Debug.Log("Distracted collider Active");
        }

        if (other.tag == "Player" && finalTriggers.hasTalkedTopher == true)
        {
        gameObject.SetActive(false);
        }
    }
}
