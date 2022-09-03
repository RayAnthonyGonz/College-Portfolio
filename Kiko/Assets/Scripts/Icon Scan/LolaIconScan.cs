using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LolaIconScan : MonoBehaviour
{
    // Start is called before the first frame update'
    private GameObject go;
    void Awake()
    {
        this.go = GameObject.Find("Talk Icon Animated Lola");
        go.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
            go.SetActive(true);
            }
        }
        void OnTriggerExit(Collider other)
        {
            go.SetActive(false);
        }
}
