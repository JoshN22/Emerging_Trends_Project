using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreNameManager : MonoBehaviour
{
    private string highScoreName;
    public static int highScorePlace;

    public GameObject HighScores;
    public GameObject HighScoreName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ReadStringInput(string input)
    {
        highScoreName = input;
        Debug.Log(highScoreName);
        if (highScorePlace == 1)
        {
            PlayerPrefs.SetString("HighScoreName1", highScoreName);
        }
        else if (highScorePlace == 2)
        {
            PlayerPrefs.SetString("HighScoreName2", highScoreName);
        }
        else if (highScorePlace == 3)
        {
            PlayerPrefs.SetString("HighScoreName3", highScoreName);
        }

        HighScores.SetActive(true);
        HighScoreName.SetActive(false);
    }
}
