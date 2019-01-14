using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTest : MonoBehaviour {

    public  Camera[] Cameras;

	// Use this for initialization
	void Start () {
		foreach(var tCam in Cameras) {
            tCam.enabled = false;
        }
        Cameras[0].enabled = true;
    }

    // Update is called once per frame
    void Update () {
        if(Input.GetKey(KeyCode.Alpha1)) {
            Cameras[0].enabled=true;
            Cameras[1].enabled = false;
            Cameras[2].enabled = false;
        }
        if (Input.GetKey(KeyCode.Alpha2)) {
            Cameras[0].enabled = false;
            Cameras[1].enabled = true;
            Cameras[2].enabled = false;
        }
        if (Input.GetKey(KeyCode.Alpha3)) {
            Cameras[0].enabled = false;
            Cameras[1].enabled = false;
            Cameras[2].enabled = true;
        }
        if (Input.GetKey(KeyCode.Alpha4)) {
            Cameras[0].enabled = false;
            Cameras[1].enabled = true;
            Cameras[2].enabled = true;
        }
    }
}
