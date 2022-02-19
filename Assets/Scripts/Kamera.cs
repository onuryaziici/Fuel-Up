using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{
    // public GameObject Cube;
    public GameObject car;
    Vector3 mesafe;
    
    void Start()
    {
        mesafe=transform.position - car.transform.position;  
    }

   
    void Update()
    {
        transform.position=car.transform.position+mesafe;
        
          Quaternion target = Quaternion.Euler(Input.GetAxis("Vertical") , 10f, 10f);

        // if(Input.GetKeyDown("a"))
        // transform.Rotate(0,0,-10f); 
        
        // if(Input.GetKeyDown("a"))
        // {
            
        //      car.transform.rotation = Quaternion.Euler(0, -10f, 0);
        //     transform.Rotate(0,0,-5f);
        // }
        // if(Input.GetKeyUp("a"))
        // {
        //     car.transform.rotation = Quaternion.Euler(0, 0, 0);
        //     // car.transform.Rotate(0,15f,0);
        //     transform.Rotate(0,0,5f);
        // }
        // if(Input.GetKeyDown("d"))
        // {
        //     car.transform.rotation = Quaternion.Euler(0, 10f, 0);
        //     transform.Rotate(0,0,5f);
        // }
        
        // if(Input.GetKeyUp("d"))
        // {
        //     car.transform.rotation = Quaternion.Euler(0, 0, 0);
        //     transform.Rotate(0,0,-5f);
        // }


// inputlara gore kamera donusleri
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                if(touch.phase == TouchPhase.Began)
                {
                    if(touch.position.x < Screen.width/2)
                    {
                        car.transform.rotation = Quaternion.Euler(0, -10f, 0);
                        // transform.Rotate(0,0,-10f);
                    }

                    else
                    {
                        car.transform.rotation = Quaternion.Euler(0, 10f, 0);
                        // transform.Rotate(0,0,10f);
                    }

                   
                }

                if(touch.phase == TouchPhase.Ended)
                {
                               car.transform.rotation = Quaternion.Euler(0, 0, 0);
                            //    transform.rotation= Quaternion.Euler(0, 0, 0);
                              if(touch.position.x < Screen.width/2)
                              {
                                    // transform.Rotate(0,0,10f);

                              }
                              else
                              {
                                //   transform.Rotate(0,0,-10f);                  
                              }

                }
                // if(touch.phase == TouchPhase.Ended)
                // {
                //      Debug.Log ("TouchPhase.Ended");
                //     car.transform.rotation = Quaternion.Euler(0, 0, 0);
                //     // car.transform.Rotate(0,15f,0);
                //     transform.Rotate(0,0,1f);
                // }
                // if(touch.position.x > Screen.width/2 )
                // {
                //     car.transform.rotation = Quaternion.Euler(0, 0.1f, 0);
                //     transform.Rotate(0,0,1f);
                // }
                
                // if(touch.phase == TouchPhase.Ended)
                // {
                //     Debug.Log ("TouchPhase.Ended");
                //     car.transform.rotation = Quaternion.Euler(0, 0, 0);
                //     transform.Rotate(0,0,-1f);
                // }
            }
        
        
        

    }
}
