using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TextManager : MonoBehaviour {

    private List<string> shownCards;
	// Use this for initialization
	void Start () {
        //LoadTextData();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadTextData()
    {

        //ListOfTextCards merda = new ListOfTextCards();
        //merda.cards = new List<TextCard>();
        //var cartamerda = new TextCard();
        //cartamerda.id = 1;
        //cartamerda.en = "fuck you unity your mumn sucks the seven dwarves cock under putin";
        //cartamerda.fi = "hardee har";
        //merda.cards.Add(cartamerda);
        //var vartamerda = new TextCard();
        //vartamerda.id = 1;
        //vartamerda.en = "fuck you unity your mumn sucks the seven dwarves cock under putin";
        //vartamerda.fi = "hardee har";
        //merda.cards.Add(vartamerda);
        //var porkoddio = JsonUtility.ToJson(merda);
        //Debug.Log(porkoddio);
        string textFileName = "Texts.json";
        string filePath = Path.Combine(Application.streamingAssetsPath, textFileName);

        if(File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            //ListOfTextCards cards = JsonUtility.FromJson<ListOfTextCards>("{\"result\":"+dataAsJson.ToString() + "}");
            ListOfTextCards cards = JsonUtility.FromJson<ListOfTextCards>(dataAsJson.ToString());
            Debug.Log(cards.cards[0].en);
            Debug.Log(cards.cards[1]);

        }

    }
    
    [System.Serializable]
    public class ListOfTextCards
    {
        public List<TextCard> cards;
    }

    [System.Serializable]
    public class TextCard
    {
        public int id;
        public string en;
        public string fi;
    }

}
