using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using PixelCrushers.QuestMachine;

public class inengQuestTrigger : MonoBehaviour
{
    public MovementControl moveControl;
    public DialogueRunner dRunner;
    public QuestGiver questGiver;
    public QuestControl questControl;
    public Day3QuestTriggers d3QuestTriggers;
    private bool hasTriggered = false;
    private bool dialogueSceneDone = false;
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

    void OnTriggerEnter(Collider other) //if true, triggers board dialogue
    {
        if (other.tag == "Player" && hasTriggered == false && d3QuestTriggers.hasWorkedVal == true
            && d3QuestTriggers.questComplete == false)
        {
        dRunner.StartDialogue("InengBuyQuest"); //trigger specific node
        moveControl.DisableMovement();
        hasTriggered = true;
        Debug.Log("board dialogue collider Active");
        }

        else if (other.tag == "Player" && hasTriggered == true && d3QuestTriggers.hasWorkedVal == true
            && d3QuestTriggers.questComplete == true && dialogueSceneDone == false)
        {
            dRunner.StartDialogue("HomeDinner");
            moveControl.DisableMovement();
            dialogueSceneDone = true;
            Debug.Log("playing dinner dialogue");
        }
    }


}

