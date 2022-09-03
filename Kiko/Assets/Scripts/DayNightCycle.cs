using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float time;
    public float startTime = 0.4f;
    
    public float newTime;
    public float intensitymultiplier;
    private float timeRate; 
    public Vector3 noon;

    [Header("Sun")]
    public Light sun;
    public Gradient sunColor;
    public AnimationCurve sunIntensity;

    [Header("Moon")]
    public Light moon;
    public Gradient moonColor;
    public AnimationCurve moonIntensity;

    [Header("Other Lighting")]
    public AnimationCurve lightingIntensityMultiplier;
    public AnimationCurve reflectionIntensityMultiplier;
    public Gradient fogColor;
    public AnimationCurve fogDensityMultiplier;

    [Header("Other Lights")]
    public Transform NightLightsContainer;
    private List<Light> nightLights;
    public Material SampleMaterial;
    [ColorUsage(true,true)]
    public Color HouseLightColor;
    [ColorUsage(true,true)]
    public Color NoLightColor;
    void Start()
    {
        nightLights = new List<Light>();
        timeRate = 0.25f;
        time = startTime;

        
        foreach (Transform child in NightLightsContainer)
        {
            Light temp = child.GetComponent<Light>();
            temp.enabled = false;
        }
        SampleMaterial.SetColor("_LightColor", NoLightColor);
    }

    public void ChangeTime(float change){
        newTime = change;
    }

    void Update() {
        //increment time
        if (time >= 1.0f){
            time = time - 1.0f;
        }
        if (newTime-0.05f >= time || time >= newTime+0.05f){
            time += timeRate * Time.deltaTime;
            
        }

        //light rotation
        sun.transform.eulerAngles = (time - 0.25f) * noon * 4.0f;
        moon.transform.eulerAngles = (time - 0.75f) * noon * 4.0f;

        //light intensity
        sun.intensity = intensitymultiplier * sunIntensity.Evaluate(time);
        moon.intensity = intensitymultiplier * moonIntensity.Evaluate(time);
        //change colors
        sun.color = sunColor.Evaluate(time);
        moon.color = moonColor.Evaluate(time);

        //enable/disable the sun
        if(sun.intensity <= 0 && sun.gameObject.activeInHierarchy){

            sun.gameObject.SetActive(false);

        }else if(sun.intensity > 0 && !sun.gameObject.activeInHierarchy){

            sun.gameObject.SetActive(true);

        }

        //enable/disable the moon and night lights
        if(moon.intensity <= 0.4f && moon.gameObject.activeInHierarchy){

            moon.gameObject.SetActive(false);
            SampleMaterial.SetColor("_LightColor", NoLightColor);
            foreach (Transform child in NightLightsContainer) { Light temp = child.GetComponent<Light>(); temp.enabled = false;}

        }else if(moon.intensity > 0.4f && !moon.gameObject.activeInHierarchy){

            moon.gameObject.SetActive(true);
            SampleMaterial.SetColor("_LightColor", HouseLightColor);
            foreach (Transform child in NightLightsContainer) { Light temp = child.GetComponent<Light>(); temp.enabled = true;}
        
        }

        //lighting and reflections intesity
        RenderSettings.ambientIntensity = lightingIntensityMultiplier.Evaluate(time);
        RenderSettings.reflectionIntensity = reflectionIntensityMultiplier.Evaluate(time);
        RenderSettings.fogColor = fogColor.Evaluate(time);
        RenderSettings.fogDensity = fogDensityMultiplier.Evaluate(time) / 10;
    }
}
