using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalAnim : MonoBehaviour
{
    public Transform box;
    private bool isShown = false;
    private Vector2 origPos;
    public Transform button;
    public Image temp;

    void Start(){
        origPos = box.localPosition;
        temp = button.GetComponent<Image>();        
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.E) && (!isShown))
        {
            showJournalAnim();
            isShown = true;
        }
         
        else if (Input.GetKeyDown(KeyCode.E) && (isShown))
        {
            hideJournalAnim();
            isShown = false;
        }


    }

    public void showJournalAnim() {
        //box.localPosition = new Vector2(0, -Screen.height);
        //box.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.1f;
        temp.CrossFadeAlpha(0.0f, 0.2f, false);
        transform.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.1f;
        
    }


    public void hideJournalAnim() {
        //box.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo();
        
        transform.LeanMoveLocal(origPos, 0.5f).setEaseInQuart().delay = 0.1f;
        temp.CrossFadeAlpha(1.0f, 0.2f, false);
    }

}
