using System.Collections;
using System.Collections.Generic;
using Yarn.Unity;
using UnityEngine;

[System.Serializable]
public class QuestGoal2 
{

    public GoalType goalType;

    //public VariableStorageBehaviour varStore = GameObject.FindGameObjectWithTag("DialogueRunner").GetComponent<VariableStorageBehaviour>();

    //public VariableStorageBehaviour varStore = GameObject.GetComponent<VariableStorageBehaviour>();
    

    // public bool hasTalked()
    // {
    //     if (varStore.TryGetValue<bool>("$talked, out var result"))
    //     {
    //         return result;
    //     }
    //     else 
    //     {
    //         return false;
    //     }
    // }




}

public enum GoalType
{
    Talk,
    Buy
}


