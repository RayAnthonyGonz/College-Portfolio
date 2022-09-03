using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class distractedBOCollider : MonoBehaviour
{
    public MovementControl moveControl;
    public DialogueRunner dRunner;
    public Day1QuestTriggers day1QuestTriggers;
    private GameObject minimap;
    // Start is called before the first frame update
    void Start()
    {
        this.minimap = GameObject.Find("MiniMapHolder");

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
        if (other.tag == "Player" && day1QuestTriggers.questComplete == false)
        {
            dRunner.StartDialogue("distractedBO");
            moveControl.DisableMovement();
            minimap.SetActive(false);
            Debug.Log("Distracted collider Active");
        }

        if (other.tag == "Player" && day1QuestTriggers.questComplete == true)
        {
            gameObject.SetActive(false);
        }
    }
}
