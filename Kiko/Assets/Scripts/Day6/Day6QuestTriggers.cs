using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using PixelCrushers.QuestMachine;
using UnityEngine.SceneManagement;

public class Day6QuestTriggers : MonoBehaviour
{
    private GameObject minimap;

    //Swap Poles Reference
    public SwapPoles swapPoles;

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

    private GameObject kiko;
    private GameObject ineng;

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        this.kiko = GameObject.Find("Main Character");
        this.ineng = GameObject.Find("Child NPC");

        this.minimap = GameObject.Find("MiniMapHolder");
        minimap.SetActive(false);

        dialogueRunner.AddCommandHandler("rescueQuest", RescueQuestTrigger);
        dialogueRunner.AddCommandHandler("talkedCouple", talkComplete); //Ineng dialogue trigger 
        dialogueRunner.AddCommandHandler("startMoving", startMovement);
        dialogueRunner.AddCommandHandler("disableMap", mapDisable);
        dialogueRunner.AddCommandHandler("enableMap", mapEnable);
        dialogueRunner.AddCommandHandler("moveSiblingsTrigger", moveSiblings);
        dialogueRunner.AddCommandHandler("toFinalScene", finalScene);
        dialogueRunner.AddCommandHandler("poleFall", triggerPole);
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

    void triggerPole()
    {
        swapPoles.Swap();
    }

    void RescueQuestTrigger()
    {
        //declare variable in dialogue scripts, call it to check if certain line is read
            questGiver.StartDialogueWithPlayer();
            Debug.Log("quest offer triggered");
    }

    void talkComplete()
    {
        //declare variable in dialogue scripts, call it to check if certain line is read
            questControl.SendToMessageSystem("talked:couple");
            questComplete = true;
            Debug.Log("Quest Complete");
    }

    public void RescueQuestComplete()
    {
        //declare variable in dialogue scripts, call it to check if certain line is read
            questControl.SendToMessageSystem("return:home");
            questComplete = true;
            dialogueRunner.StartDialogue("House2");
            moveControl.DisableMovement();
            Debug.Log("Quest Complete");
    }

    void startMovement()
    {
        moveControl.EnableMovement();
        Debug.Log("start move");
    }
    
    void moveSiblings()
    {
        kiko.transform.position = new Vector3(300f,-0.25f,3.4f);
        ineng.transform.position = new Vector3(304f,-0.25f,3.4f);
    }

    void finalScene()
    {
        SceneManager.LoadScene("Final Scene");
    }

}
