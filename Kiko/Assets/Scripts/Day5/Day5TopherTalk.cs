using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Day5TopherTalk : MonoBehaviour
{
    public MovementControl moveControl;
    public DialogueRunner dRunner;

    bool hasTriggered = false;

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
        if (other.tag == "Player" && hasTriggered == false)
        {
        dRunner.StartDialogue("topherTalk");
        moveControl.DisableMovement();
        Debug.Log("Talk Collider active");
        hasTriggered = true;
        }
    }
}
