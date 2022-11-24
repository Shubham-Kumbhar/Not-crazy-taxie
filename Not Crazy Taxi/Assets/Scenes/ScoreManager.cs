using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreManager : MonoBehaviour
{   public TMP_Text highscoreText;
    
    public int highscore;
   

    // Start is called before the first frame update
    void Start()
    {   
        highscore = PlayerPrefs.GetInt("highscore",0);
        
    }

    // Update is called once per frame
    void Update()
    {
        highscoreText.text = ((int)highscore).ToString();
    }
}
