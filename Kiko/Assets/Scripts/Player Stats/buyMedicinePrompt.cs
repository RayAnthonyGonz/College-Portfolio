using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.QuestMachine;

public class buyMedicinePrompt : MonoBehaviour
{
    //Playerstats reference
    public PlayerStats playerStats;

    //Gameobject reference for buy supplies prompt UI
    private GameObject buyMedsPrompt;
    private GameObject buyIcon;
    private GameObject insufficientPrompt;
    private GameObject fullPrompt;
    private bool iconIsActive = false;
    private int finalCurrency = 0;
    private int medsCount = 0;
    private int medCost = 100;
    // Start is called before the first frame update
    void Awake()
    {
        this.buyMedsPrompt = GameObject.Find("Buy Medicine Prompt");
        buyMedsPrompt.SetActive(false);
        this.buyIcon = GameObject.Find("Pharmacy Buy Icon");
        buyIcon.SetActive(false);
        this.insufficientPrompt = GameObject.Find("Insufficient Currency Prompt2");
        insufficientPrompt.SetActive(false);
        this.fullPrompt = GameObject.Find("Full Medicine Prompt");
        fullPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (iconIsActive == true)
            {
                buyMedsPrompt.SetActive(true);
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
        buyMedsPrompt.SetActive(false);
        Debug.Log("Buy Icon Not Active");
    }

    public void buyMedicine()
    {
        finalCurrency = playerStats.currentCurrency - medCost;
        medsCount = playerStats.currentHealth + 20;
        if (medsCount > 100){
            fullPrompt.SetActive(true);
        }else{
            if(finalCurrency < 0){
                insufficientPrompt.SetActive(true);
                Debug.Log("Cannot buy");
            }else{
                playerStats.ChangeCurrency(-100);
                playerStats.ChangeHealth(20);
                Debug.Log(playerStats.currentCurrency);
                Debug.Log(finalCurrency);
            }
        }
    }

    public void closeMedicinePrompt() 
    {
        buyMedsPrompt.SetActive(false);
    }

    public void hideInsufficientPrompt()
    {
        insufficientPrompt.SetActive(false);
    }

    public void hideMedsFullPrompt()
    {
        fullPrompt.SetActive(false);
    }
}

