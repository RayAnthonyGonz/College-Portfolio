using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.QuestMachine;

public class GameTriggers : MonoBehaviour
{
    public QuestJournal questJournal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        showJournalUI();
    }

    void showJournalUI()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            questJournal.ToggleJournalUI();
            //isShown = true;
        }
    }
}
