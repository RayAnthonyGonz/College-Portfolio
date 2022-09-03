using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.QuestMachine;

public class BuyQuestPrompt : MonoBehaviour
{
    //Gameobject reference for buy quest prompt UI
    private GameObject buyQuestPrompt;
    private GameObject buyIcon;
    private bool iconIsActive = false;
    public Day3QuestTriggers day3QuestTriggers;

    // Start is called before the first frame update
    void Awake()
    {
        this.buyQuestPrompt = GameObject.Find("Buy School Materials Prompt");
        buyQuestPrompt.SetActive(false);
        this.buyIcon = GameObject.Find("GeneralStore Buy Icon");
        buyIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (iconIsActive == true && day3QuestTriggers.questComplete == false)
            {
                buyQuestPrompt.SetActive(true);
            }
        }
    }

    void OnTriggerEnter(Collider other) //for buy prompt in quest
    {
        if (other.tag == "Player" && day3QuestTriggers.hasWorkedVal == true)
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
