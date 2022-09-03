using System.Collections;
using System.Collections.Generic;
using Yarn.Unity;
using UnityEngine;
using PixelCrushers.QuestMachine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public int maxSupply = 100;
    public int currentSupply;

    public int currency = 1000;
    public int currentCurrency;

    public int day;

    public TextMeshProUGUI currencyText;

    public HealthBar healthBar;
    public SupplyBar supplyBar;

    public StoredData data;
    public SaveandLoad snl;
    public QuestGiver questGiver;
    public QuestControl questControl;

    // Start is called before the first frame update
    void Start()
    {   
        Debug.Log("Hey this is StoredHealth " + StoredData.storedHealth);
        // Debug.Log("Hey this is StoredHunger " + data.storedHunger);
        // Debug.Log("Hey this is StoredThirst " + data.storedThirst);
        // Debug.Log("Hey this is StoredCurrency " + data.storedCurrency);
        day = StoredData.dayNumber;
        snl.SaveDataScene();
        if(StoredData.storedHealth == 0){
            // Debug.Log("StoredData!=Null | " + day);
            currentCurrency = currency;

            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);

            currentSupply = maxSupply;
            supplyBar.SetMaxSupply(maxSupply);

        }
        else if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Day 1"))
        {
            currentCurrency = 100;
            currentHealth = 100;
            currentSupply = 100;
        }
        
        else if(ES2.Exists(snl.filename))
        {
            // Debug.Log("Day > 1 | " + day);
            changeData();
            healthBar.SetHealth(currentHealth);
            supplyBar.SetSupply(currentSupply);
        }
        

    }

    //Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     ChangeHealth(-10);
        //     ChangeSupply(-10);
        //     ChangeCurrency(-200);
        // }
        
        // Debug.Log("Hey this is NewStoredHealth " + data.storedHealth);
        // Debug.Log("Hey this is NewStoredHunger " + data.storedHunger);
        // Debug.Log("Hey this is NewStoredThirst " + data.storedThirst);
        // Debug.Log("Hey this is NewStoredCurrency " + data.storedCurrency);
        currencyText.text = currentCurrency.ToString();
        healthBar.SetHealth(currentHealth);
        supplyBar.SetSupply(currentSupply); 
        //^^so that currency display value changes, putting it on start doesnt seem to work
        
     }

    public void ChangeHealth(int changeH)
    {
        currentHealth += changeH;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        if (currentHealth > 100)
        {
            currentHealth = 100;
        }

        healthBar.SetHealth(currentHealth);
    }

    public void ChangeSupply(int changeSu)
    {
        currentSupply += changeSu;

        if (currentSupply < 0)
        {
            currentSupply = 0;
        }

        if (currentSupply > 100)
        {
            currentSupply = 100;
        }

        supplyBar.SetSupply(currentSupply);
    }


    public void ChangeCurrency(int changePeso)
    {
        currentCurrency += changePeso;

        if (currentCurrency < 0)
        {
            currentCurrency = 0;
        }

    }

    public void changeData()
    {   
        StoredData.storedHealth = SaveandLoad.savedHealth;
        StoredData.storedSupply = SaveandLoad.savedSupply;
        StoredData.storedCurrency = SaveandLoad.savedCurrency;
        currentHealth = StoredData.storedHealth;
        currentSupply = StoredData.storedSupply;
        currentCurrency = StoredData.storedCurrency;
    }

}
