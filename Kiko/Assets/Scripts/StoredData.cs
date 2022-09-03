using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoredData : MonoBehaviour
{   
    public string activeSceneName;
    public string[] sceneName;
    public string Day;
    public static int dayNumber;
    public PlayerStats MCsData;
    public static int storedHealth;
    public static int storedSupply;
    public static int storedCurrency;

    // Start is called before the first frame update
    void Start()
    {
        activeSceneName = SceneManager.GetActiveScene().name;
        sceneName = activeSceneName.Split(' ');
        Day = sceneName[0];
        dayNumber = int.Parse(sceneName[1]);

        // PlayerStats MCsData = MCsData.GetComponent<PlayerStats>();
        Debug.Log("Found it!");
        

        // storedHealth = MCsData.GetComponent("Player Stats").currentHealth;
        // // storedThirst = MCsData.GetComponent(PlayerStats).currentThirst;
        // // storedHunger = MCsData.GetComponent(PlayerStats).currentHunger;
        // // storedCurrency = MCsData.GetComponent(PlayerStats).currentCurrency;
        
        Debug.Log(Day + " " + dayNumber);
        
        

    }

    public void nextDay()
    {
        // Start();
        // MCsData.currentHealth = storedHealth;
        // MCsData.currentHunger = storedHunger;
        // MCsData.currentThirst = storedThirst;
        // MCsData.currentCurrency = storedCurrency;
        dayNumber = dayNumber + 1;
        // Debug.Log("Next Day should load" + Day + " " + dayNumber);
        // Debug.Log("Current Data for Day: " + dayNumber);
        
        SceneManager.LoadScene("Day " + dayNumber);
        
        //PixelCrushers.SaveSystem.LoadScene("Day " + dayNumber);
        
    }
    
    // Update is called once per frame
    void Update()
    {
        storeDN();
    }

    public void storeDN()
    {
        storedHealth = MCsData.currentHealth;
        storedSupply = MCsData.currentSupply;
        storedHealth -= 10;
        storedSupply -= 20;
        storedCurrency = MCsData.currentCurrency;
    }
}
