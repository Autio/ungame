using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AppController : MonoBehaviour {
    // Icon made by Freepik from www.flaticon.com 
    public GameObject[] cameraPoints;
    public GameObject camera;
    // Need a data structure for this to parse and fill out texts accordingly. 
    // This needs to be thought through.
    // Main level, sublevel1, sublevel2

    private float c = 1.0f;
    // Use this for initialization
    void Start () {
        camera = GameObject.Find("Main Camera");

	}
	
	// Update is called once per frame
	void Update () {
        c -= Time.deltaTime;
        if (c < 0 && c > -1)
        {
            LoadTexts();
            c = -10;
        }
	}

    public void SlideCamera(int a)
    {
        float duration = 0.6f;
        camera.transform.DOMoveX(cameraPoints[a].transform.position.x, duration);

    }

    public void LoadTexts()
    {
        LocalisationManager.instance.LoadLocalisedText("localizedText_en.json");
    }

    public void DisplayNextCard()
    {
        string cardText = LocalisationManager.instance.NextCard();
        Debug.Log(cardText);
        GameObject.Find("CardText").GetComponent<Text>().text = cardText;
    }
}
