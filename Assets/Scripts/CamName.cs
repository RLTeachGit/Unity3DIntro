using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamName : MonoBehaviour {

    public Camera Cam;

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = Cam.name;   //Put name in text to help ID
	}
}
