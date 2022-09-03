using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.QuestMachine;

public class centralStoreTopher : MonoBehaviour
{
    //Gameobject reference for buy quest prompt UI
    private GameObject buyTopherQuestPrompt;
    private GameObject buyIcon;
    private bool iconIsActive = false;
    public Day5QuestTriggers day5QuestTriggers;

    // Start is called before the first frame update
    void Awake()
    {
        this.buyTopherQuestPrompt = GameObject.Find("Buy Topher Supplies Prompt");
        buyTopherQuestPrompt.SetActive(false);
        this.buyIcon = GameObject.Find("CentralStore Buy Icon (1)");
        buyIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (iconIsActive == true && day5QuestTriggers.hasTalkedTopher == true)
            {
                buyTopherQuestPrompt.SetActive(true);
            }
        }
    }

    void OnTriggerEnter(Collider other) //for buy prompt in quest
    {
        if (other.tag == "Player")
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
        buyTopherQuestPrompt.SetActive(false);
        Debug.Log("Buy Icon Not Active");
    }

    public void closeBuyQuestPrompt() 
    {
        buyTopherQuestPrompt.SetActive(false);
    }
}
