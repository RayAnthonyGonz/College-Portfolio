using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest2
{
    public bool isActive;

    public string title;
    public string description;
    //public int currencyReward;
    public int healthReward;
    public int hungerReward;
    public int thirstReward;

    public QuestGoal2 goal;

    public void Complete()
    {
        isActive = false;
        Debug.Log(title + "was completed!");
    }

}
