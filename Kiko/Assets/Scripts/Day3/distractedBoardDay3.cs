using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class distractedBoardDay3 : MonoBehaviour
{
    public MovementControl moveControl;
    public DialogueRunner dRunner;
    public Day3QuestTriggers day3QuestTriggers;
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
        if (other.tag == "Player" && day3QuestTriggers.hasReadBoard == false)
        {
            dRunner.StartDialogue("distractedBoard");
            moveControl.DisableMovement();
            Debug.Log("Distracted collider Active");
            Debug.Log(day3QuestTriggers.hasReadBoard);
        }

        if (other.tag == "Player" && day3QuestTriggers.hasReadBoard == true)
        {
            gameObject.SetActive(false);
        }
    }
}
