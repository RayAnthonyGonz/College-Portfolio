using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SwapPoles : MonoBehaviour
{
    public bool isBroken;
    public GameObject Broken;
    public GameObject Normal;
    
    public CinemachineVirtualCamera VirtualCamera;
    // Start is called before the first frame update
    void Start()
    {
        VirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
    }
    public void Swap(){
        isBroken = !isBroken;
        StartCoroutine(ShakeStart());
        
    }
    IEnumerator ShakeStart(){
        VirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 10;
        yield return new WaitForSeconds(1);
        VirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (isBroken){
            Normal.SetActive(false);
            Broken.SetActive(true);
        }else{
            Normal.SetActive(true);
            Broken.SetActive(false);
        }
    }
    
}
