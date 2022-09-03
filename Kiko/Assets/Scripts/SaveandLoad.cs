using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveandLoad : MonoBehaviour
{   
    
    public string savedScene;
    public string[] SavedScene;
    public string savedDay;
    public static int savedDayNum;
    public string filename = "Kiko'sSaveWorld.txt";
    public string filename1 = "Kiko'sSaveHP.txt";
    public string filename2 = "Kiko'sSaveSupply.txt";
    public string filename3 = "Kiko'sSaveCurrency.txt";
    public string filename4 = "Kiko'sSaveResolution.txt";
    public string filename5 = "Kiko'sSaveVolume.txt";
    public string filename6 = "Kiko'sSaveIsFullscreen.txt";
    public string savedSceneName;
    public static int savedHealth;
    public static int savedSupply;
    public static int savedCurrency;
    public static int savedResolutionValue;
    public static bool savedisFullscreen;
    public static float savedVolume; 
    public int viewIndex;
    public StoredData SD;
    public SettingsMenu SM;


    // Start is called before the first frame update
    void Start()
    {
        
        if(ES2.Exists(filename)){
            // savedScene = ES2.Load<string>(filename+"?tag=Untagged");
            // savedDayNum = ES2.Load<int>(filename+"?tag=Untagged");
            // savedHealth = ES2.Load<int>(filename1+"?tag=Untagged");
            // savedSupply = ES2.Load<int>(filename2+"?tag=Untagged");
            // savedCurrency = ES2.Load<int>(filename3+"?tag=Untagged");
            // Debug.Log("Hmmmm savedHealth" + savedHealth);
            // Debug.Log("Hmmmm savedSupply" + savedSupply);
            // Debug.Log("Hmmmm savedCurrency" + savedCurrency);
            

        }
        
        savedDayNum = ES2.Load<int>("Kiko'sSaveWorld.txt?tag=Untagged");
        //Debug.Log(savedDayNum);
        // Debug.Log(savedScene);
        // if(SceneManager.GetActiveScene().name == savedScene){
            
        // }


    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(SM.resolutionDropdown.value);
        
        viewIndex = savedResolutionValue;
        savedHealth = StoredData.storedHealth;
        savedSupply = StoredData.storedSupply;
        savedCurrency = StoredData.storedCurrency;
        savedResolutionValue = SM.resolutionDropdown.value;
        savedVolume = SettingsMenu.volumeValue;
        
        // Debug.Log("Here is the savedScene: " + savedScene);
        // Debug.Log("Here is the savedHealth: " + savedHealth);
        // Debug.Log("Here is the Invertory Space: " + savedSupply);
        // Debug.Log("Here is the savedCurrency: " + savedCurrency);
        
    }


    public void LoadDataScene()
    {   
        //Debug.Log(savedDayNum);
        if(savedDayNum != 0){
           SceneManager.LoadScene("Day " + savedDayNum);
            transferData(); 
        }
        else if(savedDayNum == 0){
            SceneManager.LoadScene("Day 1");
            transferData();
        }
        // SceneManager.LoadScene("Day " + savedDayNum);
        // transferData();
            // Debug.Log(savedDayNum);
            // Debug.Log(savedHealth);
            // Debug.Log(StoredData.storedHealth);
            
        // transferData();
    }

    public void transferData()
    {
        savedHealth = ES2.Load<int>(filename1+"?tag=Untagged");
        savedSupply = ES2.Load<int>(filename2+"?tag=Untagged");
        savedCurrency = ES2.Load<int>(filename3+"?tag=Untagged");
        
        StoredData.storedHealth = savedHealth;
        StoredData.storedSupply = savedSupply;
        StoredData.storedCurrency = savedCurrency;
        // Debug.Log("Hmmmm savedHealth" + savedHealth);
        // Debug.Log("Hmmmm savedSupply" + savedSupply);
        // Debug.Log("Hmmmm savedCurrency" + savedCurrency);
    }
    // void OnApplicationQuit()
    // {
    //     SaveDataScene();
    // }
    public void SaveDataScene()
    {   
        // Debug.Log("SaveHP Function: " + savedHealth);
        // Debug.Log("SaveSupply Function: " + savedSupply);
        // Debug.Log("SaveCurrency Function: " + savedCurrency);
        savedScene = SceneManager.GetActiveScene().name;
        // Debug.Log(savedScene);
        SavedScene = savedScene.Split(' ');
        // Debug.Log(savedScene[0]);
        savedDay = SavedScene[0];
        savedDayNum = int.Parse(SavedScene[1]);
        // Debug.Log(savedDayNum);
        // savedHealth = savedHealth - 10;
        // savedSupply = savedSupply - 10;
        ES2.Save(savedDayNum,filename+"?tag=Untagged");
        ES2.Save(savedHealth,filename1+"?tag=Untagged");
        ES2.Save(savedSupply,filename2+"?tag=Untagged");
        ES2.Save(savedCurrency,filename3+"?tag=Untagged");
        
        Debug.Log("Save Compelte!!!");
    }

    public void SaveSettings()
    {   
        savedisFullscreen = SettingsMenu.isFullscreen;
        // Debug.Log(savedisFullscreen);
        ES2.Save(savedResolutionValue,filename4+"?tag=Untagged");
        ES2.Save(savedVolume, filename5+"?tag=Untagged");
        ES2.Save(savedisFullscreen, filename6+"?tag=Untagged");
        Debug.Log("Settings Saved!!!");
    }
    
    public void LoadSettings()
    {
        savedResolutionValue = ES2.Load<int>(filename4+"?tag=Untagged");
        savedVolume = ES2.Load<float>(filename5+"?tag=Untagged");
        savedisFullscreen = ES2.Load<bool>(filename6+"?tag=Untagged");
    }

}   


