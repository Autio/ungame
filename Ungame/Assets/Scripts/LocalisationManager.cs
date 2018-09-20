using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public class LocalisationManager : MonoBehaviour {
    public static LocalisationManager instance;

    private Dictionary<string, string> localisedText;
    private bool isReady = false;
    private string missingTextString = "Localised text not found";

    private List<string> keys = new List<string>();
    private List<string> usedKeys = new List<string>();

    private void Start()
    {

       // LoadLocalisedText("localizedText_en.json");
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }

    public void LoadLocalisedText(string fileName)
    {
        LocalisationData loadedData = null;
        localisedText = new Dictionary<string, string>();
        string filePath = Path.Combine("jar:file://" + Application.dataPath + "!/assets/", fileName);
        if (Application.platform == RuntimePlatform.Android)
        {
            // Android
            filePath = System.IO.Path.Combine(Application.streamingAssetsPath, fileName);

            WWW reader = new WWW(filePath);
            while (!reader.isDone) { }
            loadedData = JsonUtility.FromJson<LocalisationData>(reader.text);



        }
        else
        {
            filePath = Path.Combine(Application.streamingAssetsPath, fileName); // PC
            string dataAsJSON = File.ReadAllText(filePath);
            loadedData = JsonUtility.FromJson<LocalisationData>(dataAsJSON);

        }

        for (int i = 0; i < loadedData.items.Length; i++)
        {
            localisedText.Add(loadedData.items[i].key, loadedData.items[i].value);
            keys.Add(loadedData.items[i].key);
        }

    }

    public string NextCard(string type = "n")
    {

        string result = "Thanks for playing!";

        // Check if usedKeys is full
        if (keys.Count == usedKeys.Count)
        {
            // Here we go again!
            usedKeys.Clear();
        }

        for (int i = 0; i < 50; i++)
        {
            string cardKey = keys[Random.Range(0, keys.Count)];
            if (cardKey.Substring(0, 1) == type)
            {
                if (!usedKeys.Contains(cardKey))
                {
                    usedKeys.Add(cardKey);
                    result = localisedText[cardKey];
                    return result;
                }
            }
        }

        return result;
    }

    [System.Serializable]
    public class LocalisationData
    {
        public LocalisationItem[] items;

    }
    [System.Serializable]
    public class LocalisationItem
    {
        public string key;
        public string value;
    }
}
