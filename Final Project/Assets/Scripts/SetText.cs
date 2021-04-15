using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetText : MonoBehaviour
{

    public TextMeshProUGUI highScoreText1;
    public TextMeshProUGUI highScoreText2;
    public TextMeshProUGUI highScoreText3;

    // Start is called before the first frame update
    void Start()
    {
        highScoreText1.SetText($"1: {PlayerPrefs.GetString("HighScoreName1")} {PlayerPrefs.GetInt("HighScore1")}");
        highScoreText2.SetText($"2: {PlayerPrefs.GetString("HighScoreName2")} {PlayerPrefs.GetInt("HighScore2")}");
        highScoreText3.SetText($"3: {PlayerPrefs.GetString("HighScoreName3")} {PlayerPrefs.GetInt("HighScore3")}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
