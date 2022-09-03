using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using PixelCrushers.QuestMachine;

public class Day2QuestTriggers : MonoBehaviour
{
    public AudioSource phoneDial;
    private GameObject minimap;
    private GameObject questIconBO;

    //Dialogue Runner References
    public VariableStorageBehaviour varStore;
    public DialogueRunner dialogueRunner;

    public DayNightCycle daynightCycle;

    //Quest Machine References
    public QuestGiver questGiver;
    public QuestControl questControl;

    //Playerstats reference
    public PlayerStats playerStats;

    //Gameobject reference for relief goods scene
    private GameObject reliefGoodsPeople;

    //movement control reference
    public MovementControl moveControl;

    public bool questComplete = false;
    public bool hasWorkedVal = false;
    public bool hasTalkedTopher = false;

    // Start is called before the first frame update
    void Start()
    {
        this.reliefGoodsPeople = GameObject.Find("Relief Goods people");
        reliefGoodsPeople.SetActive(false);

        this.minimap = GameObject.Find("MiniMapHolder");
        minimap.SetActive(false);

        

        dialogueRunner.AddCommandHandler("talkedElderly", TalkQuestEvaluateCouple); //elder dialogue trigger 
        dialogueRunner.AddCommandHandler("goToWork", hasWorked); //has worked trigger
        dialogueRunner.AddCommandHandler("talkedBO", TalkQuestEvaluateBO);
        dialogueRunner.AddCommandHandler("startMoving", startMovement);
        dialogueRunner.AddCommandHandler("disableMap", mapDisable);
        dialogueRunner.AddCommandHandler("enableMap", mapEnable);
        dialogueRunner.AddCommandHandler("disableQuestIcon", questIconDisable);
        dialogueRunner.AddCommandHandler("talkQuestStart", triggerTalkQuest);
        dialogueRunner.AddCommandHandler("startTopherQuest", triggerTopherQuest);
        dialogueRunner.AddCommandHandler("doneTalk", topherTalkEval);
        dialogueRunner.AddCommandHandler("dinnerInengTalk", dinnerTalkIneng);
        dialogueRunner.AddCommandHandler("phoneDial", PlayDialSound);
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

    void questIconDisable()
    {
        questIconBO.SetActive(false);
    }

    void PlayDialSound()
    {
        phoneDial.Play();
    }

    void dinnerTalkIneng()
    {
        questControl.SendToMessageSystem("talked:ineng");
    }

    void triggerTopherQuest()
    {
        questControl.SendToMessageSystem("start:TopherQuest");
    }

    void topherTalkEval()
    {
        questControl.SendToMessageSystem("talk:Topher");
        hasTalkedTopher = true;
    }

    void triggerTalkQuest()
    {
        questGiver.StartDialogueWithPlayer();  //Shows Quest Window which starts quest
    }

    void TalkQuestEvaluateCouple()
    {
        //declare variable in dialogue scripts, call it to check if certain line is read
        if (varStore.TryGetValue<bool>("$ElderlyTalk", out var result)) 
        {
            questControl.SendToMessageSystem("Talk:Couple");
            questControl.SendToMessageSystem("start:workTrigger"); //start go to work subquest
            Debug.Log("Talk to npc successful");
        }
        else
        {
            Debug.Log("Talk to npc unsuccessful");
        }
    }

    void TalkQuestEvaluateBO()
    {
        //declare variable in dialogue scripts, call it to check if certain line is read
        if (varStore.TryGetValue<bool>("$BOReliefGoods", out var result)) 
        {
            //questControl.SendToMessageSystem("Talk:Couple");
            // playerStats.ChangeHealth(10);
            Debug.Log("Talk to npc successful");
        }

    }

    void hasWorked()
    {
        if (varStore.TryGetValue<bool>("$driverTalk", out var result)) 
        {
            questControl.SendToMessageSystem("has:worked");
            playerStats.ChangeCurrency(-20);
            playerStats.ChangeCurrency(200);
            daynightCycle.ChangeTime(0.85f);
            hasWorkedVal = true;
            reliefGoodsPeople.SetActive(true);
            this.questIconBO = GameObject.Find("Quest Indicator BO");
            questIconBO.SetActive(true);
            Debug.Log("Has worked, timelapsing day to night");
        }

    }

    void startMovement()
    {
        moveControl.EnableMovement();
        Debug.Log("start move");
    }

}
