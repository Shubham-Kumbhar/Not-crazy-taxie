using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{   
    public static GameManager inst;
    public GameObject Canvasmains;


    public Slider timeSlider;
    public float gameTime;
    public bool stopTimer;
    public GameObject gameover;


    public TMP_Text TimerText;
    public float StartTime;
    public float tleft = 25;
    public float incrementtime = 10;
    public float timeshow;

    public PlayGames pg;


   



    // Start is called before the first frame update
    void Start()
    {   Canvasmains.SetActive(true);
        stopTimer = false;
        timeSlider.maxValue = 35;
        timeSlider.value=timeshow;
        StartTime = Time.time;
    }
    float timeshow2;
    // Update is called once per frame
    public void Update()
    {   
        // if (tleft>=35)
        // {
        //     tleft =35;
        // }
        
        float t = Time.time - StartTime;
        timeshow = tleft-t;

        timeshow2 = Mathf.Floor(timeshow);

        float secondscheck = timeshow2%60;

        string minutes = ((int) timeshow / 60).ToString();
        
        string seconds = ((int)timeshow%60).ToString("f0");

        if (secondscheck>9)
        {
            TimerText.text = minutes + ":" + seconds;
            timeSlider.value=timeshow; 
        }
        else
        {
            TimerText.text = minutes + ":" + "0" + seconds;
            timeSlider.value=timeshow;
        }
        
        timeEnd();

    }

    public void increasetime()
    {
        tleft += incrementtime;
    }

    public void nothing()
    {
        Debug.Log("FJFEJFOFJOFJ");
    }

    
    void timeEnd()
    {
        if (timeshow<=0)
        {
            gameover.SetActive(true);
            Invoke("endtimedelay", 2f);
            Debug.Log("game over");
            Canvasmains.SetActive(false);
            
        }
        
       
    }
    public void endtimedelay()
    {   

        SceneManager.LoadScene(3);
        pg.AddScoreToLeaderboard();
    }
   
}
