using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleporterScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 TP1;
    private Vector3 TP2;
    public RainStop rain;
    public Color fadeColor; 
    // private Image blackScreen;
    private Image img;
    private GameObject collided;

    //movement control reference
    public MovementControl moveControl;
    void Start()
    {
        img = GameObject.Find("TeleporterFade").GetComponent<Image>();
        rain = GameObject.Find("Rain").GetComponent<RainStop>();
        TP1 = GameObject.Find("TP Target 1").transform.position;
        TP2 = GameObject.Find("TP Target 2").transform.position;
    }

    IEnumerator FadeToBlack()
    {
        // loop over 1 second
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            // set color with i as alpha
            fadeColor.a = i;
            img.color = fadeColor;
            yield return null;
        }
        if(this.gameObject.name == "TP Target 1"){
            collided.gameObject.transform.position = TP2;
            rain.Outdoor = false;
        }else{
            collided.gameObject.transform.position = TP1;
            rain.Outdoor = true;
        }
        yield return null;
        StartCoroutine(FadeFromBlack());
    }
    IEnumerator FadeFromBlack()
    {
        yield return new WaitForSeconds(1);
        for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                fadeColor.a = i;
                img.color = fadeColor;
                yield return null;
            }
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
        moveControl.EnableMovement();
    }
    
    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Player")
        {   
            collided = other.gameObject;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            moveControl.DisableMovement();
            StartCoroutine(FadeToBlack());
            
        }
    }   
}
