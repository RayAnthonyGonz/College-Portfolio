using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float min;
    public float max;
    public float sensitivity;
    // Start is called before the first frame update
    private Vector3 maxPos;
    private Vector3 minPos;
    public GameObject Self;
    public GameObject PSelf;
    private char direction = ' ';
    private float time;
    void Start()
    {
        minPos = new Vector3(0, 0, -1 * min);
        maxPos = new Vector3(0, 0, -1 * max);
    }
    // Update is called once per frame
    void Update()
    {
        if((Input.GetAxis("Mouse ScrollWheel") != 0) == true){
            if (gameObject.transform.localPosition.z > maxPos.z && gameObject.transform.localPosition.z < minPos.z){
                //float tempZ = gameObject.transform.localPosition.z + Input.GetAxis("Mouse ScrollWheel");
                Vector3 newPos = new Vector3(
                    Self.transform.localPosition.x,
                    Self.transform.localPosition.y, 
                    Self.transform.localPosition.z + (Input.GetAxis("Mouse ScrollWheel") * sensitivity)); 
                    transform.localPosition = newPos;
                if (Input.GetAxis("Mouse ScrollWheel") > 0){
                    direction = 'F';
                }else{
                    direction = 'B';
                }
            }else{
                if (direction == 'B'){
                    Vector3 newPos = new Vector3(
                    Self.transform.localPosition.x,
                    Self.transform.localPosition.y, 
                    maxPos.z+1); 
                    transform.localPosition = newPos;
                }else{
                    Vector3 newPos = new Vector3(
                    Self.transform.localPosition.x,
                    Self.transform.localPosition.y, 
                    minPos.z-1); 
                    transform.localPosition = newPos;
                }
            }
        }
    }
}
