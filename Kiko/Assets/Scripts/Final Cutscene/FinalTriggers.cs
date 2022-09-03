using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class FinalTriggers : MonoBehaviour
{
    public AudioSource bgMusic;

    //Dialogue Runner References
    public VariableStorageBehaviour varStore;
    public DialogueRunner dialogueRunner;

    //movement control reference
    public MovementControl moveControl;

    private GameObject credits;
    public bool hasTalkedTopher = false;

    // Start is called before the first frame update
    void Start()
    {
        this.credits = GameObject.Find("Credits");
        credits.SetActive(false);

        dialogueRunner.AddCommandHandler("startMoving", startMovement);
        dialogueRunner.AddCommandHandler("startCredits", enableCredits);
        dialogueRunner.AddCommandHandler("hasTalked", talkedTopher);
        dialogueRunner.AddCommandHandler("playBGMusic", bgPlay);      
        dialogueRunner.StartDialogue("kikoStart");
        moveControl.DisableMovement(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void talkedTopher()
    {
        hasTalkedTopher = true;
    }

    void bgPlay()
    {
        bgMusic.Play();
    }

    void startMovement()
    {
        moveControl.EnableMovement();
        Debug.Log("start move");
    }

    void enableCredits()
    {
        credits.SetActive(true);
    }
}
