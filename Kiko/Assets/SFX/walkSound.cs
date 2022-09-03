using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkSound : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource AudioSource;
    [SerializeField]
    public AudioClip[] WaterAudio;
    public AudioClip[] DirtAudio;
    public bool inWater;
    private void Awake()
    {
        AudioSource = this.GetComponent<AudioSource>();
    }
    
    public void Step()
    {
        AudioClip clip = GetRandomClip();
        AudioSource.PlayOneShot(clip);
        
    }

    AudioClip GetRandomClip(){
        if(inWater){
            return WaterAudio[UnityEngine.Random.Range(0, WaterAudio.Length)]; 
        }else{
            return DirtAudio[UnityEngine.Random.Range(0, DirtAudio.Length)]; 
        }
    }
}
