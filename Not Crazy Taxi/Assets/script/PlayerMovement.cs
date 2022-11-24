using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{   
    public PlayGames thePG;


    public TMP_Text SpeedText;
    public AudioSource Crashsound;
    public AudioSource Jumpsound;

    public float moveSpeed;
   
    public float runSpeed;
    public float MaxRunSpeed;
    public Vector3 moveDirection;
    public CharacterController controller;
    public float lane = 0.0f;
    public bool isCollided = false;
    public GameObject DestroyParticle;

    
    public bool IsGrounded = true;
    public float GroundCheckDistance;
    public LayerMask GroundMask;
    public float Gravity;
    public float JumpHeight;
    public Vector3 velocity ;

    public      CarRay theCr;
    public      CarRay theCr1;
    public      CarRay theCr2;
    public      CarRay theCr3;
    public      CarRay theCr4;
    public      CarRay theCr5;
    public      CarRay theCr6;

    public int highscore;
    public int currentscore;
    public TMP_Text highscoreText;
    public TMP_Text currentscoreText;
    

    
    public int temprun;
    public float temprun2;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        

    }

    public int achievementcounter = 0;

    // Update is called once per frame
    void Update()
    {   
        
        
        
        Vector3 position = this.transform.position;
            currentscore = (int)position.z;
            highscore = PlayerPrefs.GetInt("highscore",0);
            // thePG.AddScoreToLeaderboard();
            if (currentscore >= highscore)
            {
                PlayerPrefs.SetInt("highscore",currentscore);
                
            }

        currentscoreText.text = ((int)currentscore).ToString();
        highscoreText.text = ((int)highscore).ToString();




        if(highscore >= 150 && achievementcounter == 0)
        {
            achievementcounter =1;
            thePG.UnlockAchievement1();

        }
        if(highscore >= 500 && achievementcounter == 1)
        {
            achievementcounter = 2;
            thePG.UnlockAchievement2();

        }
        if(highscore >= 1000 && achievementcounter == 2)
        {
            achievementcounter =3;
            thePG.UnlockAchievement3();

        }
        if(highscore >= 1500 && achievementcounter == 3)
        {
            achievementcounter =4;
            thePG.UnlockAchievement4();

        }

        if(highscore >= 2000 && achievementcounter == 4)
        {
            achievementcounter = 5;
            thePG.UnlockAchievement5();

        }
            



        temprun2 = (runSpeed-4.0f)*25.0f;
        temprun = (int)temprun2;

        string dispspeed = ((int) temprun).ToString();
        SpeedText.text = dispspeed;
        
        move();

        IsGrounded=Physics.CheckSphere(transform.position,GroundCheckDistance,GroundMask);
         if (IsGrounded && velocity.y<0)
        {
            velocity.y=-2f;
        }
        velocity.y+=Gravity*Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void Jump()

    {
        if(IsGrounded)
        {   Debug.Log("i jump");
            Jumpsound.Play();
            velocity.y=Mathf.Sqrt(JumpHeight*-2*Gravity);
            
        }
        
    }


    public void move()

    {
        float moveZ = 1;

        moveDirection = new Vector3(lane,0,moveZ);
        moveDirection *= runSpeed;
        controller.Move(moveDirection *Time.deltaTime);
        if(runSpeed <= MaxRunSpeed)
        {
            runSpeed += 0.3f * Time.deltaTime;
        }
       
    }
    
     public void OnControllerColliderHit(ControllerColliderHit other)
    {
        //Check to see if the tag on the collider is equal to Enemy

        if(other.gameObject.tag=="Enemy" && isCollided == false )
       
        {   isCollided = true;

            Debug.Log("Triggered by Enemy");
            Crashsound.Play();


            DestroyParticle.SetActive(true);

            theCr.Crashed();
            theCr1.Crashed();
            theCr2.Crashed();
            theCr3.Crashed();
            theCr4.Crashed();
            theCr5.Crashed();
            theCr6.Crashed();


            
            Destroy(other.gameObject);

            Invoke ("resetcollider", 1.0f);
            Invoke ("resetray", 0.2f);
            Crashedthecar();


        }



       
    }

    public void resetcollider()
    {
        isCollided = false;
        DestroyParticle.SetActive(false);
        
    }

    public void resetray()
    {
        theCr.Crashedreset();
        theCr1.Crashedreset();
        theCr2.Crashedreset();
        theCr3.Crashedreset();
        theCr4.Crashedreset();
        theCr5.Crashedreset();
        theCr6.Crashedreset();
    }

    public void Crashedthecar()
    {
        float temp = runSpeed;
        if(temp >= 6)
        {
            runSpeed = temp - 2f;
        }
        else
        {
            runSpeed = 4;
        }
    }
    

    

}
