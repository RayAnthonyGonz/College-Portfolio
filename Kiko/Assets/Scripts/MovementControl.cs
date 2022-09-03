using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;

public class MovementControl : MonoBehaviour
{
    private PlayMakerFSM fsm;
    private PlayMakerFSM fsm2;
    private FsmFloat xSpeedVar;
    private FsmFloat zSpeedVar;
    private FsmVector3 MovementVector;
    private GameObject MainCharacter;
    // Start is called before the first frame update
    void Start()
    {
        MainCharacter = GameObject.Find("Main Character");
        fsm = PlayMakerFSM.FindFsmOnGameObject(GameObject.Find("Main Character"), "Movement");
        fsm2 = PlayMakerFSM.FindFsmOnGameObject(GameObject.Find("Main Character"), "Flipper");
        MovementVector = FsmVariables.GlobalVariables.FindFsmVector3("MovementVector");
        xSpeedVar = FsmVariables.GlobalVariables.FindFsmFloat("x speed");
        zSpeedVar = FsmVariables.GlobalVariables.FindFsmFloat("z speed");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableMovement()
    {
        MainCharacter.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        fsm.enabled=false;
        fsm2.enabled=false;
        xSpeedVar.Value = 0;
        zSpeedVar.Value = 0;
        MovementVector.Value = new Vector3(0,0,0);
    }

    public void EnableMovement()
    {
        fsm.enabled=true;
        fsm2.enabled=true;
    }
}
