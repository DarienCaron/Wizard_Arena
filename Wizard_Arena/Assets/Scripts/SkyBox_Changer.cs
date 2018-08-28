using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBox_Changer : MonoBehaviour {
     public enum SkyBoxes
    {
        Evening,
        Night
    }

    public SkyBoxes SkyBoxChoice;

    public Material Evening;
    public Material Night;
	// Use this for initialization
	void Start () {
		
        if(SkyBoxChoice == SkyBoxes.Evening)
        {
            RenderSettings.skybox = Evening;
        }
        else if(SkyBoxChoice == SkyBoxes.Night)
        {
            RenderSettings.skybox = Night;
        }
	}
	
	
}
