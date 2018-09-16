using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LocalisationManager : MonoBehaviour {
    public static LocalisationManager instance;

    private Dictionary<string, string> localisedText;
    private bool isReady = false;
    private string missingTextString = "Localised text not found";


    private void Start()
    {

        LoadLocalisedText("cardsEn.json");
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
        localisedText = new Dictionary<string, string>();
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            LocalisationData loadedData = JsonUtility.FromJson<LocalisationData>(dataAsJson);
                
            for (int i = 0; i < loadedData.items.Length; i++)
            {
                localisedText.Add(loadedData.items[i].key, loadedData.items[i].value);
            }

        }
        else
        {
            Debug.LogError("Cannot find localisation file!");
        }
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
