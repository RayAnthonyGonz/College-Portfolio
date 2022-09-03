using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestWindowAnim : MonoBehaviour
{
    public Transform questWindowBox;
    private bool isShown = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showQuestWindow() {
        //box.localPosition = new Vector2(0, -Screen.height);
        //box.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.1f;
        transform.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.1f;
    }


    public void hideQuestWindow() {
        //box.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo();
        transform.LeanMoveLocal(new Vector2(0, 975), 0.5f).setEaseInQuart();
    }

}
