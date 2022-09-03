using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using PixelCrushers.QuestMachine;

public class Day3QuestTriggers : MonoBehaviour
{
    private GameObject minimap;

    //for transition next day
    public StoredData transition;

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
    public bool hasReadBoard = false;

    void Awake()
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

    // Start is called before the first frame update
    void Start()
    {
        this.minimap = GameObject.Find("MiniMapHolder");
        minimap.SetActive(false);

        dialogueRunner.AddCommandHandler("InengQuest", InengQuestTrigger); //Ineng dialogue trigger 
        dialogueRunner.AddCommandHandler("goToWork", hasWorked); //has worked trigger
        dialogueRunner.AddCommandHandler("startMoving", startMovement);
        dialogueRunner.AddCommandHandler("disableMap", mapDisable);
        dialogueRunner.AddCommandHandler("enableMap", mapEnable);
        dialogueRunner.AddCommandHandler("boardQuestComplete", completeBoardQuest);
        dialogueRunner.AddCommandHandler("triggerAtHome", homeTrigger);
        dialogueRunner.AddCommandHandler("nextDay", dayNext);
        dialogueRunner.StartDialogue("HomeMorning");
        moveControl.DisableMovement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InengQuestEvaluate()
    {
        //declare variable in dialogue scripts, call it to check if certain line is read
            questControl.SendToMessageSystem("Buy:SchoolSupplies");
            playerStats.ChangeCurrency(-250);
            buyQuestPrompt.closeBuyQuestPrompt();
            questComplete = true;
            Debug.Log("Succesfully bought");
    }

    void InengQuestTrigger()
    {
        //declare variable in dialogue scripts, call it to check if certain line is read
        if (varStore.TryGetValue<bool>("$InengQuestTalk", out var result)) 
        {
            questGiver.StartDialogueWithPlayer();
            questControl.SendToMessageSystem("talk:ineng");
            Debug.Log("Talk to npc successful");
        }
        else
        {
            Debug.Log("Talk to npc unsuccessful");
        }
    }

    void hasWorked()
    {
        if (varStore.TryGetValue<bool>("$driverTalk", out var result)) 
        {
            playerStats.ChangeCurrency(-20);
            daynightCycle.ChangeTime(0.9f);
            playerStats.ChangeCurrency(200);
            questControl.SendToMessageSystem("has:worked");
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

    void completeBoardQuest()
    {
        hasReadBoard = true;
        questControl.SendToMessageSystem("checked:board");
        Debug.Log("hakdog");
        Debug.Log(hasReadBoard);
    }

    void homeTrigger()
    {
        questControl.SendToMessageSystem("at:home");
    }
    
    
    void dayNext()
    {
        transition.nextDay();
    }


}
