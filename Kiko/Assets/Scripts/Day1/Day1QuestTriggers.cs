using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using PixelCrushers.QuestMachine;

public class Day1QuestTriggers : MonoBehaviour
{
    public AudioSource phoneDial;
    public AudioSource metalPoundSound;
    private GameObject tutorial;
    private GameObject tutorialCollider;
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
    public ElderlyBuyQuestPrompt elderBuyQuestPrompt;

    //movement control reference
    public MovementControl moveControl;

    public bool questComplete = false;
    public bool questCompleteCouple = false;
    public bool hasBought = false;

    // Start is called before the first frame update
    void Start()
    {
        this.tutorial = GameObject.Find("Tutorial Initial Start");
        tutorial.SetActive(false);

        this.tutorialCollider = GameObject.Find("tutorialCollider");
        this.minimap = GameObject.Find("MiniMapHolder");
        minimap.SetActive(false);

        dialogueRunner.AddCommandHandler("talkChecked", TalkQuestEvaluate); //dialogue trigger
        dialogueRunner.AddCommandHandler("startMoving", startMovement);
        dialogueRunner.AddCommandHandler("disableMap", mapDisable);
        dialogueRunner.AddCommandHandler("enableMap", mapEnable);
        dialogueRunner.AddCommandHandler("startBOQuest", triggerBOTalkQuest);
        dialogueRunner.AddCommandHandler("talkCoupleTrigger", triggerCoupleTalk);
        dialogueRunner.AddCommandHandler("talkedCoupleTrigger", triggerCoupleTalked);
        dialogueRunner.AddCommandHandler("talkIneng", homeTalkTrigger);
        dialogueRunner.AddCommandHandler("enableTutorial", tutorialEnable);
        dialogueRunner.AddCommandHandler("phoneDial", PlayDialSound);
        dialogueRunner.AddCommandHandler("metalDoor", PlayMetalPoundSound); 
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

    void tutorialEnable()
    {
        tutorial.SetActive(true);
        Debug.Log("opened tutorial");
    }

    void PlayDialSound()
    {
        phoneDial.Play();
    }

    void PlayMetalPoundSound()
    {
        metalPoundSound.Play();
    }

    void homeTalkTrigger()
    {
        questControl.SendToMessageSystem("talk:ineng");
    }

    public void ElderBuyQuestEvaluate()
    {
        //declare variable in dialogue scripts, call it to check if certain line is read
            questControl.SendToMessageSystem("buy:supplies");
            elderBuyQuestPrompt.closeBuyQuestPrompt();
            hasBought = true;
            daynightCycle.ChangeTime(0.9f);
            dialogueRunner.StartDialogue("OpeningCutscene");
            moveControl.DisableMovement();
            varStore.SetValue("$hasBought", true);
            Debug.Log("Succesfully bought");
    }

    void TalkQuestEvaluate()
    {
        //declare variable in dialogue scripts, call it to check if certain line is read
        if (varStore.TryGetValue<bool>("$talkedBO", out var result)) 
        {
            questControl.SendToMessageSystem("Talk:BO");
            //daynightCycle.ChangeTime(1f);
            questComplete = true;
            questControl.SendToMessageSystem("start:elderQuest");
            Debug.Log("Talk to npc successful");
        }
        else
        {
            Debug.Log("Talk to npc unsuccessful");
        }
    }

    public void triggerBOTalkQuest()
    {
        questGiver.StartDialogueWithPlayer(); //Shows Quest Window which starts quest
        tutorialCollider.SetActive(false);
    }

    void startMovement()
    {
        moveControl.EnableMovement();
        Debug.Log("start move");
    }

    void triggerCoupleTalk()
    {
        questControl.SendToMessageSystem("talk:couple");
    }

    void triggerCoupleTalked()
    {
        questControl.SendToMessageSystem("talked:couple");
        playerStats.ChangeSupply(30);
        questCompleteCouple = true;
    }

}
