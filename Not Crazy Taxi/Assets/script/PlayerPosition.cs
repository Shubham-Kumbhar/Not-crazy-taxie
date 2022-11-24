using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{   

    public CharacterController controller;
    public int currentlane = 0;
    


    // Start is called before the first frame update
    void Start()
    {
      
        controller = GetComponent<CharacterController>();
    }

    void update()
    {
        Vector3 position = this.transform.position; 
        if(position.y <= 0.0f) 
        {
             controller.enabled=false;
             position.y =2.0f;
             this.transform.position = position; 
             controller.enabled=true;
        }
    }

    public void moveleft()
    {  
        if(currentlane == 0)
        {
            controller.enabled=false;
            Vector3 position = this.transform.position;
            position.x =-1.0f;
            currentlane = -1;
            this.transform.position = position; 
            controller.enabled=true;
            
        }

        else if(currentlane == 1)
        {
            controller.enabled=false;
            Vector3 position = this.transform.position;
            position.x =-0.02f;
            currentlane = 0;
            this.transform.position = position; 
            controller.enabled=true;
            
        }
        
    }
    public void moveRight()
    {   if(currentlane == 0)
        {
            controller.enabled=false;
            Vector3 position = this.transform.position;
            position.x =0.95f;
            currentlane = 1;
            this.transform.position = position; 
            controller.enabled=true;
            
        }

        else if(currentlane == -1)
        {
            controller.enabled=false;
            Vector3 position = this.transform.position;
            position.x =-0.02f;
            this.transform.position = position; 
            controller.enabled=true;
            currentlane = 0;
        }
    }
}