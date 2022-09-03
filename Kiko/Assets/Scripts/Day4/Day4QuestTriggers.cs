using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using PixelCrushers.QuestMachine;

public class Day4QuestTriggers : MonoBehaviour
{
    private GameObject minimap;

    //Dialogue Runner References
    public VariableStorageBehaviour varStore;
    public DialogueRunner dialogueRunner;

    public DayNightCycle daynightCycle;

    //Quest Machine References
    public QuestGiver questGiver;
    public QuestControl questControl;

    //Playerstats reference
    public PlayerStats playerStats;

    //Gameobject reference for buy quest prompt UI
    public BuyQuestPrompt buyQuestPrompt;

    //movement control reference
    public MovementControl moveControl;

    public bool questComplete = false;
    public bool hasWorkedVal = false;

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        this.minimap = GameObject.Find("MiniMapHolder");
        minimap.SetActive(false);

        dialogueRunner.AddCommandHandler("talkingQuestTrigger", talkQuestTrigger); //talk quest trigger
        dialogueRunner.AddCommandHandler("talkElder1Eval", talk1Eval);
        dialogueRunner.AddCommandHandler("hasWorked", goWorkEval);
        dialogueRunner.AddCommandHandler("disableMap", mapDisable);
        dialogueRunner.AddCommandHandler("enableMap", mapEnable);
        dialogueRunner.AddCommandHandler("talkElder2Eval", talk2Eval);
        dialogueRunner.AddCommandHandler("talkedIneng", inengTalked);
        dialogueRunner.AddCommandHandler("goToWork", hasWorked); //has worked trigger
        dialogueRunner.AddCommandHandler("startMoving", startMovement);
        dialogueRunner.StartDialogue("HomeMorning");
        moveControl.DisableMovement();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mapDisable()
    {
        minimap.SetActive(false);
    }

    void mapEnable()
    {
        minimap.SetActive(true);
    }

    void inengTalked()
    {
        questControl.SendToMessageSystem("talked:ineng");
    }


    void talkQuestTrigger()
    {
            questGiver.StartDialogueWithPlayer();
    }

    public void talk1Eval()
    {
        questControl.SendToMessageSystem("talk:elderly");
    }

    public void goWorkEval()
    {
        questControl.SendToMessageSystem("has:worked");
    }

    public void talk2Eval()
    {
        questControl.SendToMessageSystem("talked:elderly");
    }

    void hasWorked()
    {
        if (varStore.TryGetValue<bool>("$driverTalk", out var result)) 
        {
            playerStats.ChangeCurrency(-20);
            daynightCycle.ChangeTime(0.9f);
            playerStats.ChangeCurrency(200);
            hasWorkedVal = true;
            Debug.Log("Has worked, timelapsing day to night");
        }
        else
        {
            Debug.Log("Talk to npc unsuccessful");
        } 
    }

    void startMovement()
    {
        moveControl.EnableMovement();
        Debug.Log("start move");
    }
    
    //add function that disables Lolo NPC script if talkQuest is not true, else enable it


}
