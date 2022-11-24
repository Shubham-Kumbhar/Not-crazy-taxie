using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRay : MonoBehaviour
{   public PlayerMovement theGM;
    public int CrashedCar = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    /////////ACTIVATE THIS JAB GAMEMANAGER BAN JAYE//////////////////
    void Update()
    {
       Ray ray = new Ray (transform.position, transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast (ray, out hitInfo, 8) && CrashedCar == 1 )
        {   
            Debug.DrawLine (ray.origin, hitInfo.point, Color.red);
            Destroy (hitInfo.transform.gameObject);
            
            
        }
        else
        {
             Debug.DrawLine (ray.origin, ray.origin + ray.direction *8, Color.green);
        }
    }

    public void Crashed()
    {
         CrashedCar = 1;
    }

    public void Crashedreset()
    {
        CrashedCar = 0;
    }
}
