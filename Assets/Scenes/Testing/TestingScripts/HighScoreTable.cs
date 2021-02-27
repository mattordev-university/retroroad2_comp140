using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoreTable : MonoBehaviour {

    public Transform entryContainer;
    public Transform entryTemplate;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;

    private void Awake()
    {
        entryContainer = transform.Find("highscoreEntryContainer");
        //entryTemplate = transform.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        //Test list
        /*highscoreEntryList = new List<HighscoreEntry>() {
            new HighscoreEntry { score = 521854, name = "AAA" },
            new HighscoreEntry { score = 321415, name = "ANN" },
            new HighscoreEntry { score = 455415, name = "CAT" },
            new HighscoreEntry { score = 614312, name = "JON" },
            new HighscoreEntry { score = 103563, name = "DED" },
            new HighscoreEntry { score = 784531, name = "MAA" },
            new HighscoreEntry { score = 135134, name = "DAA" },
            new HighscoreEntry { score = 12302, name = "LAA" },
        };*/

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscore = JsonUtility.FromJson<Highscores>(jsonString);

        //Sort the entry list by score
        for (int i = 0; i < highscoreEntryList.Count; i++)
        {
            for (int j=i +1; j<highscoreEntryList.Count; j++)
            {
                if (highscoreEntryList[j].score > highscoreEntryList[i].score)
                {
                    //Swap
                    HighscoreEntry tmp = highscoreEntryList[i];
                    highscoreEntryList[i] = highscoreEntryList[j];
                    highscoreEntryList[j] = tmp;
                }
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
        /*
        Highscores highscores = new Highscores { highscoreEntryList = highscoreEntryList };
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("highscoreTable"));
        */
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHieght = 20f;

        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHieght * transformList.Count);
        entryTransform.gameObject.SetActive(true);


        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH";
                break;

            case 1:
                rankString = "1ST";
                break;
            case 2:
                rankString = "2ND";
                break;
            case 3:
                rankString = "3RD";
                break;

        }

        entryTransform.Find("posText").GetComponent<TextMeshProUGUI>().text = rankString;


        int score = highscoreEntry.score;

        entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();

        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().text = name;

        transformList.Add(entryTransform);
    }

    private void AddHighscoreEntry(int score, string name)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score };
    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    //This represents a single highscore entry
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }
	
}
