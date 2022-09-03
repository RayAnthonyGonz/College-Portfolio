using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class DeathHandler : MonoBehaviour
{
    public GameObject DeathScreen;
    private PlayerStats MCsData;
    public CanvasGroup DeathScreenCanvasGroup;
    public TMP_Text deathMessage;
    private GameObject black;
    private bool STOP = false;

    void Start()
    {
        DeathScreenCanvasGroup.alpha = 0.0f;
    
    }
    // Update is called once per frame
    void Update()
    {
        MCsData = GameObject.Find("Player Stats").GetComponent<PlayerStats>();
        if (this.name == "Death Handler" && (MCsData.currentHealth <= 0 || MCsData.currentSupply <= 0)){
            if(!STOP){
                Debug.Log("SPAWN DEATH");
                GameObject go = Instantiate(DeathScreen, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                go.transform.SetParent(this.transform, false);
                STOP = true;
            }
        }
        if (this.name == "Menu button" || this.name == "Restart button" ){
            DeathScreenCanvasGroup.alpha += 0.02f;
            if (MCsData.currentHealth <= 0){
                deathMessage.text = "Kiko lost too much health and died";
            }else{
                if(MCsData.currentSupply <= 0){
                    deathMessage.text = "Kiko ran out of supplies and couldn't survive";
                }
            }
        }
    }

    public void RestartDay(){
        PixelCrushers.SaveSystem.LoadScene("Day " + (SceneManager.GetActiveScene().buildIndex + 0));
    }

    public void GoToMainMenu(){
        SceneManager.LoadScene("Main Menu");
    }
}
