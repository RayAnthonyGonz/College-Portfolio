using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class rescueQuestCollider : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public MovementControl moveControl;

    public Day6QuestTriggers day6Triggers;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && day6Triggers.questComplete == true)
        {
            day6Triggers.RescueQuestComplete();
        }
    }


}
