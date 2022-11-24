using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointRay : MonoBehaviour
{   

    public LayerMask CheckMask;
    public GameManager theGM;


    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    void Update()
    {
        Ray ray = new Ray (transform.position, transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast (ray, out hitInfo, 15, CheckMask) )
        {
            Debug.DrawLine (ray.origin, hitInfo.point, Color.red);
            Debug.Log("Check crossed");
            theGM.increasetime();
            Destroy (hitInfo.transform.gameObject);

            
        }
        else
        {
             Debug.DrawLine (ray.origin, ray.origin + ray.direction *15, Color.green);
        }
    }
}