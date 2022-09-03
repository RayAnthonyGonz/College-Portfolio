using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using PixelCrushers.QuestMachine;

public class BoardDialogueCollider : MonoBehaviour
{
    public MovementControl moveControl;
    public DialogueRunner dRunner;
    public QuestGiver questGiver;
    public QuestControl questControl;
    public Day3QuestTriggers day3QuestTriggers;
    private bool hasTriggered = false;
    // Start is called before the first frame update
    void Start()
    {
        dRunner.AddCommandHandler("EnableMovement", startMovement); //enable movement from yarn script
        dRunner.AddCommandHandler("triggerBoardQuest", boardQuestTrigger);
        //dRunner.AddCommandHandler("boardQuestComplete", completedBoardQuest);
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
        if (other.tag == "Player" && hasTriggered == false &&
        day3QuestTriggers.hasReadBoard == false)
        {
        dRunner.StartDialogue("BeforeBoard"); //trigger specific node
        moveControl.DisableMovement();
        hasTriggered = true;
        Debug.Log("board dialogue collider Active");
        }

        if (other.tag == "Player" && day3QuestTriggers.hasReadBoard == true && 
        hasTriggered == true)
        {
            gameObject.SetActive(false);
        }
    }

    public void boardQuestTrigger() 
    {
        questControl.SendToMessageSystem("trigger:beforeBoardCollider");
        //questGiver.StartDialogueWithPlayer();
        Debug.Log("sent message");
    }

    // public void completedBoardQuest() 
    // {
    //     questControl.SendToMessageSystem("checked:board");
    //     Debug.Log("complete quest sent message");
    // }
}

