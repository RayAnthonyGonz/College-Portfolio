using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DinnerTalkTrigger : MonoBehaviour
{
    private bool talkedIneng = false;

    public StoredData transition;
    //Current Day Quest Trigger Used
    public Day2QuestTriggers day2Triggers;

    //Dialogue Runner Reference
    public DialogueRunner dialogueRunner;

    //movement control reference
    public MovementControl moveControl;

    // Start is called before the first frame update
    void Start()
    {
        dialogueRunner.AddCommandHandler("nextDay", dayNext);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) //for buy prompt in quest
    {
        if (other.tag == "Player" && day2Triggers.hasWorkedVal == true && talkedIneng == false) //vary per day
        {
        dialogueRunner.StartDialogue("HomeDinner");
        moveControl.DisableMovement();
        talkedIneng = true;
        Debug.Log("Dinner Talk Start");
        }
    }

    void dayNext()
    {
        transition.nextDay();
    }

}
