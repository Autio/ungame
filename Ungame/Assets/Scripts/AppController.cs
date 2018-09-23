using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

//TODO
// Optional timer
// Backwards navigation
// Theme selector
// Credits? 
// Monetization

public class AppController : MonoBehaviour {
    

    public GameObject[] cameraPoints;
    public GameObject camera;
    public int roundsPlayed = 0;
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
        string cardText;
        if (roundsPlayed < 4)
        {
            cardText = LocalisationManager.instance.NextCard("w");
        } else
        {
            cardText = LocalisationManager.instance.NextCard();
        }
        roundsPlayed++;
        Debug.Log(cardText);

        GameObject.Find("CardText").GetComponent<Text>().text = cardText;
    }

    // First screen
    // Swoop in the logo: Connection Cards
    // Tagline: A Deeper Connection
    

}
