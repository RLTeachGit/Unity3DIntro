using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchLight : MonoBehaviour {

    MeshRenderer mMR;

    [SerializeField]
    Light ColourLight;

    [SerializeField]
    Color MatColour;

	// Use this for initialization
	void Start () {
        mMR = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        mMR.material.color = ColourLight.color;
	}
}
