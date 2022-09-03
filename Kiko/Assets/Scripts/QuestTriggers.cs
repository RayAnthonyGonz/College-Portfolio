using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using PixelCrushers.QuestMachine;

public class QuestTriggers : MonoBehaviour
{
    //Dialogue Runner References
    public VariableStorageBehaviour varStore;
    public DialogueRunner dialogueRunner;

    //Quest Machine References
    public QuestGiver questGiver;
    public QuestControl questControl;

    public PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        questGiver.StartDialogueWithPlayer(); //Shows Quest Window which starts quest

        dialogueRunner.AddCommandHandler("talkChecked", testQuestEvaluate); //dialogue trigger 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void testQuestEvaluate()
    {
        //declare variable in dialogue scripts, call it to check if certain line is read
        if (varStore.TryGetValue<bool>("$talked", out var result)) 
        {
            questControl.SendToMessageSystem("Talked:NPC");
            playerStats.ChangeHealth(10);
            playerStats.ChangeSupply(10);
            Debug.Log("quest condition true");
        }
        else
        {
            Debug.Log("quest condition false");
        }
    }
}
