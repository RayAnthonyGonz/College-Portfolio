using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.QuestMachine;

public class ElderlyBuyQuestPrompt : MonoBehaviour
{
    //Gameobject reference for buy quest prompt UI
    private GameObject buyQuestPrompt;
    private GameObject buyIcon;
    private bool iconIsActive = false;
    public Day1QuestTriggers day1QuestTriggers;

    // Start is called before the first frame update
    void Awake()
    {
        this.buyQuestPrompt = GameObject.Find("Buy Quest Supplies Prompt");
        buyQuestPrompt.SetActive(false);
        this.buyIcon = GameObject.Find("CentralStore Buy Icon");
        buyIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (iconIsActive == true && day1QuestTriggers.questComplete == true && day1QuestTriggers.questComplete == true)
            {
                buyQuestPrompt.SetActive(true);
            }
        }
    }

    void OnTriggerEnter(Collider other) //for buy prompt in quest
    {
        if (other.tag == "Player" && day1QuestTriggers.questComplete == true && day1QuestTriggers.hasBought == false)
        {
        buyIcon.SetActive(true);
        iconIsActive = true;
        Debug.Log("Buy Icon Active");
        }
    }

    void OnTriggerExit(Collider other) //if player exits collider
    {
        buyIcon.SetActive(false);
        iconIsActive = false;
        Debug.Log("Buy Icon Not Active");
    }

    public void closeBuyQuestPrompt() 
    {
        buyQuestPrompt.SetActive(false);
    }
}
