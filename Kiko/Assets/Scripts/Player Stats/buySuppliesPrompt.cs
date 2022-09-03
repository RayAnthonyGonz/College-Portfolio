using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.QuestMachine;

public class buySuppliesPrompt : MonoBehaviour
{
    //Playerstats reference
    public PlayerStats playerStats;

    //Gameobject reference for buy supplies prompt UI
    private GameObject buySupplyPrompt;
    private GameObject buyIcon;
    private GameObject insufficientPrompt;
    private GameObject fullPrompt;
    private bool iconIsActive = false;
    private int finalCurrency = 0;
    private int supplyCount = 0;
    private int supplyCost = 280;

    // Start is called before the first frame update
    void Awake()
    {
        this.buySupplyPrompt = GameObject.Find("Buy Supplies Prompt");
        buySupplyPrompt.SetActive(false);
        this.buyIcon = GameObject.Find("CentralStore Buy Icon");
        buyIcon.SetActive(false);
        this.insufficientPrompt = GameObject.Find("Insufficient Currency Prompt");
        insufficientPrompt.SetActive(false);
        this.fullPrompt = GameObject.Find("Full Supplies Prompt");
        fullPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (iconIsActive == true)
            {
                buySupplyPrompt.SetActive(true);
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
        buySupplyPrompt.SetActive(false);
        Debug.Log("Buy Icon Not Active");
    }

    public void buySupplies()
    {
        finalCurrency = playerStats.currentCurrency - supplyCost; // calculating future currency
        supplyCount = playerStats.currentSupply + 30; //calculating new supply edits
        // if (finalCurrency >= 0 && supplyCount <= 100) //checking if he has enough money
        // {                                             //and if supplies is not overstocked
        //     playerStats.ChangeCurrency(-280);
        //     playerStats.ChangeSupply(30);
        //     Debug.Log(playerStats.currentCurrency);
        //     Debug.Log(finalCurrency);
        // }else{
        //     if (supplyCount > 100) //if he is claculated to overstock
        //     {
        //         fullPrompt.SetActive(true);
        //     }else{
        //         insufficientPrompt.SetActive(true);
        //         Debug.Log("Cannot buy");
        //     }
        // }
        if (supplyCount > 100){
            fullPrompt.SetActive(true);
        }else{
            if(finalCurrency < 0){
                insufficientPrompt.SetActive(true);
                Debug.Log("Cannot buy");
            }else{
                playerStats.ChangeCurrency(-280);
                playerStats.ChangeSupply(30);
                Debug.Log(playerStats.currentCurrency);
                Debug.Log(finalCurrency);
            }
        }
    }

    public void closeSupplyPrompt() 
    {
        buySupplyPrompt.SetActive(false);
    }

    public void hideInsufficientPrompt()
    {
        insufficientPrompt.SetActive(false);
    }

    public void hideFullSuppliesPrompt()
    {
        fullPrompt.SetActive(false);
    }

}
