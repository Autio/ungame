using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AppController : MonoBehaviour {
    // Icon made by Freepik from www.flaticon.com 
    public GameObject[] cameraPoints;
    public GameObject camera;
    // Need a data structure for this to parse and fill out texts accordingly. 
    // This needs to be thought through.
    // Main level, sublevel1, sublevel2


    // Use this for initialization
    void Start () {
        camera = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SlideCamera(int a)
    {
        float duration = 0.6f;
        camera.transform.DOMoveX(cameraPoints[a].transform.position.x, duration);

    }
}
