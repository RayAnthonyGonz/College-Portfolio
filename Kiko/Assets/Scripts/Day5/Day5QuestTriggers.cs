using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using PixelCrushers.QuestMachine;

public class Day5QuestTriggers : MonoBehaviour
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

    //Quest Status Check
    public bool buyFortMat = false;
    public bool hasTalkedTopher = false;
    public bool hasTalkedElderly = false;
    public bool fortQuestFinished = false;
    public bool topherQuestFinished = false;
    public bool elderQuestFinished = false;
    public bool gotSuppliesElderly = false;
    public bool boughtTopherSupplies = false;

    //Fortification reference
    private GameObject fort;

    //To hide supplies reference
    private GameObject hide1;
    private GameObject hide2;
    private GameObject hide3;
    private GameObject hide4;

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        this.fort = GameObject.Find("Fortifications");
        fort.SetActive(false);

        this.minimap = GameObject.Find("MiniMapHolder");
        minimap.SetActive(false);

        //Hide supplies reference
        this.hide1 = GameObject.Find("Canned Goods (3)");
        this.hide2 = GameObject.Find("Canned Goods (4)");
        this.hide3 = GameObject.Find("Canned Goods (5)");
        this.hide4 = GameObject.Find("Relief goods");

        dialogueRunner.AddCommandHandler("buyFortSuppliesStart", fortSuppliesStart); //has worked trigger
        dialogueRunner.AddCommandHandler("triggerTopherQuest", questTopherTrigger);
        dialogueRunner.AddCommandHandler("elderQuestStart", questElderTrigger);
        dialogueRunner.AddCommandHandler("startMoving", startMovement);
        dialogueRunner.AddCommandHandler("disableMap", mapDisable);
        dialogueRunner.AddCommandHandler("enableMap", mapEnable);
        dialogueRunner.AddCommandHandler("giveSupplies", suppliesGive);
        dialogueRunner.AddCommandHandler("finishedTopherQuest", completeTopherQuest);
        dialogueRunner.AddCommandHandler("finishedElderQuest", completeElderQuest);
        dialogueRunner.AddCommandHandler("finishedFortQuest", completeFortQuest);
        dialogueRunner.AddCommandHandler("showfortification", activateFort);
        dialogueRunner.AddCommandHandler("hideSupplies", suppliesHide);
        dialogueRunner.AddCommandHandler("gotSupplies", suppliesGot);
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

    void suppliesGive()
    {
        playerStats.ChangeSupply(30);
    }

    void startMovement()
    {
        moveControl.EnableMovement();
        Debug.Log("start move");
    }
    
    void fortSuppliesStart()
    {
        questGiver.StartDialogueWithPlayer();
    }

    void completeFortQuest()
    {
        questControl.SendToMessageSystem("has:fortified");
        fortQuestFinished = true;
    }
    
    void questTopherTrigger()
    {
        questControl.SendToMessageSystem("start:TopherQuest");
        hasTalkedTopher = true;
    }

    void completeTopherQuest()
    {
        questControl.SendToMessageSystem("talked:Topher");
        topherQuestFinished = true;
        playerStats.ChangeCurrency(500);
    }

    void questElderTrigger()
    {
        questControl.SendToMessageSystem("start:elderQuest");
        hasTalkedElderly = true;
    }

    void completeElderQuest()
    {
        questControl.SendToMessageSystem("talked:Elderly");
        elderQuestFinished = true;
    }

    public void buyFortMaterials()
    {
        questControl.SendToMessageSystem("bought:materials");
        playerStats.ChangeCurrency(-500);
        buyFortMat = true;
        Debug.Log(buyFortMat);
        Debug.Log("Bought Fort Materials");
    }

    void activateFort()
    {
        fort.SetActive(true);
    }

    void suppliesHide()
    {
        hide1.SetActive(false);
        hide2.SetActive(false);
        hide3.SetActive(false);
        hide4.SetActive(false);
        gotSuppliesElderly = true;
    }

    void suppliesGot()
    {
        questControl.SendToMessageSystem("got:Supplies");
        playerStats.ChangeSupply(-30);
        varStore.SetValue("$suppliesGot", true);
    }

    public void buyTopherSupplies()
    {
        questControl.SendToMessageSystem("bought:topherMats");
        boughtTopherSupplies = true;
        varStore.SetValue("$topherSupplies", true);
    }
    


}
