using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTest : MonoBehaviour {

    public  Camera[] Cameras;

	// Use this for initialization
	void Start () {
		foreach(var tCam in Cameras) {
            tCam.gameObject.SetActive(false);
        }
        Cameras[0].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
        if(Input.GetKey(KeyCode.Alpha1)) {
            Cameras[0].gameObject.SetActive(true);
            Cameras[1].gameObject.SetActive(false);
            Cameras[2].gameObject.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Alpha2)) {
            Cameras[0].gameObject.SetActive(false);
            Cameras[1].gameObject.SetActive(true);
            Cameras[2].gameObject.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Alpha3)) {
            Cameras[0].gameObject.SetActive(false);
            Cameras[1].gameObject.SetActive(false);
            Cameras[2].gameObject.SetActive(true);
        }
        if (Input.GetKey(KeyCode.Alpha4)) {
            Cameras[0].gameObject.SetActive(false);
            Cameras[1].gameObject.SetActive(true);
            Cameras[2].gameObject.SetActive(true);
        }
    }
}
