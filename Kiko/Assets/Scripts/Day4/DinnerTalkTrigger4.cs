using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DinnerTalkTrigger4 : MonoBehaviour
{
    //Reference StoreData (for loading next scene)
    public StoredData loadScene;

    //Current Day Quest Trigger Used
    public Day4QuestTriggers day4Triggers;

    //Dialogue Runner Reference
    public DialogueRunner dialogueRunner;

    //movement control reference
    public MovementControl moveControl;

    // Start is called before the first frame update
    void Start()
    {
        dialogueRunner.AddCommandHandler("nextDay", nextDayStart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) //for buy prompt in quest
    {
        if (other.tag == "Player" && day4Triggers.hasWorkedVal == true) //vary per day
        {
        dialogueRunner.StartDialogue("HomeDinner");
        moveControl.DisableMovement();
        Debug.Log("Dinner Talk Start");
        }
    }

    void nextDayStart()
    {
        loadScene.nextDay();
    }

}
