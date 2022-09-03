using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class getSuppliesTrigger : MonoBehaviour
{
    public MovementControl moveControl;
    public DialogueRunner dRunner;
    private GameObject interactIcon;
    private bool iconIsActive = false;
    public Day5QuestTriggers day5Triggers;

    private bool hasFortified = false;
    // Start is called before the first frame update
    void Start()
    {
        this.interactIcon = GameObject.Find("Interact Icon Get Supplies");
        interactIcon.SetActive(false);

        dRunner.AddCommandHandler("EnableMovement", startMovement); //enable movement from yarn script
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (iconIsActive == true && day5Triggers.hasTalkedElderly == true && day5Triggers.gotSuppliesElderly == false)
            {
                dRunner.StartDialogue("gettingSupplies");
                moveControl.DisableMovement();
                hasFortified = true;
                Debug.Log("Fortify collider Active");
            }
        }

    }

    void startMovement()
    {
        moveControl.EnableMovement();
        Debug.Log("start move");
    }

    void OnTriggerEnter(Collider other) //if true, triggers dialogue
    {
        if (other.tag == "Player" && day5Triggers.hasTalkedElderly == true && day5Triggers.gotSuppliesElderly == false) 
        {
            interactIcon.SetActive(true);
            iconIsActive = true;
        }
    }

    void OnTriggerExit(Collider other) //if player exits collider
    {
        interactIcon.SetActive(false);
        iconIsActive = false;
        Debug.Log("Interact Icon Not Active");
    }

}
