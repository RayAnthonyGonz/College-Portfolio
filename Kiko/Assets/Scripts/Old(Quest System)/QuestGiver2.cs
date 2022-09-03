using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class QuestGiver2 : MonoBehaviour
{
    public QuestWindowAnim questWindowAnimScript;

    public Quest2 quest;

    //public PlayerStats playerStats;

    public GameObject questWindow;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    //public Text currencyText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI hungerText;
    public TextMeshProUGUI thirstText;


    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        //currencyText.text = quest.currency.ToString;
        //healthText.text = quest.healthReward.ToString();
        //hungerText.text = quest.hungerReward.ToString();
        //thirstText.text = quest.thirstReward.ToString();
        
        questWindowAnimScript.showQuestWindow();
        Debug.Log("Quest Window Active");

    }

    // public void AcceptQuest()
    // {
    //     quest.isActive = true;
    //     playerStats.quest = quest;
    // }


}
