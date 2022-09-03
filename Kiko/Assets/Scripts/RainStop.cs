using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RainStop : MonoBehaviour
{
    // Start is called before the first frame update
    public bool RainingDay;
    public bool Outdoor;
    void Update() {
        if (RainingDay && Outdoor){
            this.GetComponent<ParticleSystem>().Play();
            this.GetComponentInChildren<ParticleSystem>().Play();
            if(!this.GetComponent<AudioSource>().isPlaying){
                this.GetComponent<AudioSource>().UnPause();
            }else{
                this.GetComponent<AudioSource>().Play();
            }
        }else{
            this.GetComponent<ParticleSystem>().Stop();
            this.GetComponentInChildren<ParticleSystem>().Stop();
            this.GetComponent<AudioSource>().Pause();
        }
    }
}
