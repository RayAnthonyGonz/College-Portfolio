using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Day5DistractedTalkCollider : MonoBehaviour
{
    public MovementControl moveControl;
    public DialogueRunner dRunner;
    public Day5QuestTriggers day5Triggers;

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
        if (other.tag == "Player" && day5Triggers.hasTalkedTopher == false)
        {
            dRunner.StartDialogue("distractedTalkTopher");
            moveControl.DisableMovement();
            Debug.Log("Distracted collider Active");
        }

        if (other.tag == "Player" && day5Triggers.hasTalkedTopher == true)
        {
            gameObject.SetActive(false);
        }
    }
}
