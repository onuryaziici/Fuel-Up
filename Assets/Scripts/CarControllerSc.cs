using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CarControllerSc : MonoBehaviour
{
    public ParticleSystem faster;
    public GameObject GameOverPanel;
    public static bool gameOver=false;
    public float speed=10.0f;
    public float score=0;
    public Rigidbody rb;
    public Vector3 movement;
    private float time;
    public Transform yol1;
    public Transform yol2;
    public float zaman;
    public float topspeed;
    public TMPro.TextMeshProUGUI speed_txt;
    public TMPro.TextMeshProUGUI score_txt;
    public TMPro.TextMeshProUGUI score2_txt;

    Vector3 m_EulerAngleVelocity;

    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider rearLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;
    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform rearLeftWheelTransform;
    public Transform rearRightWheelTransform;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        faster.Stop();
        rb=this.GetComponent<Rigidbody>();
         m_EulerAngleVelocity = new Vector3(0, 10, 0);
         faster=GameObject.Find("faster").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"),0,0);
        float xPosition = Mathf.Clamp(transform.position.x,-14f,14f);
        float xPosition2 = Mathf.Clamp(transform.position.x,-14f,14f);
        if (Input.touchCount > 0)
         {
             var touch = Input.GetTouch(0);
             if (touch.position.x < Screen.width/2)
             {
                //  transform.position= new Vector3(xPosition,transform.position.y,transform.position.z);
                 movement = new Vector3(-0.5f,0,0);
             }
             else if (touch.position.x > Screen.width/2)
             {
                //   transform.position= new Vector3(xPosition,transform.position.y,transform.position.z);
                 movement = new Vector3(0.5f,0,0);
             }
         }
        
    }

    void FixedUpdate()
    {
        UpdateWheels();
        moveCharacter(movement);

        time = time + Time.fixedDeltaTime;

        rb.drag = 0.01f*(score/100);

        // if (Input.GetKeyDown("h"))
        //             {
        //                 Time.timeScale = 0.0f;
        //                 Debug.Log("Pressed H");
        //                gameOver = true;
        //                Debug.Log(gameOver);
        //                 GameOverPanel.SetActive(true);


        // if (Input.GetKeyDown("x"))
        //             {
                        
        //             Debug.Log(gameOver);
        //                          Vector3 kuvvetbaslangıc=new Vector3(0,0,-300000.0f);
        //                         rb.AddForce(kuvvetbaslangıc);
                       
                       
                         
        //             }
        
        // if(gameOver==true)
        // {
        //     speed_txt.enabled =false;
        //     score_txt.enabled= false;

        // }

        if (speed <= 0.5f && time>10.0f || gameOver==true)  //GAME OVER CONDITION
                    {
                        speed_txt.enabled =false;
                        score_txt.enabled= false;
                        gameOver = true;
                         Time.timeScale = 0.0f;
                        GameOverPanel.SetActive(true);
                        //  SceneManager.LoadScene("Score");
                    }
        if (speed <= 15f )
                {
                    rb.drag=1f;
                }

        if (time < 3.0f)
        {
            Vector3 kuvvetbaslangıc=new Vector3(0,0,30000.0f);
            rb.AddForce(kuvvetbaslangıc);
        }

        speed = CarSpeed();
        speed=rb.velocity.magnitude;
        speed_txt.text=speed.ToString("0"+"km/h");

        score=(transform.position.z+90)/10;
        score_txt.text=score.ToString("0");
        score2_txt.text=score.ToString("0");
        
        


    }

    void moveCharacter(Vector3 direction)
    {
        float xPosition = Mathf.Clamp(transform.position.x,-16f,16f);
        // rb.MovePosition(transform.position+(direction*speed*Time.deltaTime));
        rb.MovePosition(new Vector3(xPosition,transform.position.y,transform.position.z)+(direction*speed*Time.deltaTime));
        
       
        

    }  

    public float CarSpeed()
    {
            topspeed=150;
            // float speed2 =rb.velocity.magnitude;
            // speed2*=3.6f;
        if(speed>topspeed)
            {
                rb.velocity=(topspeed)*rb.velocity.normalized;
               
            }
             return speed;
    }

    private void OnTriggerEnter(Collider other)
        {
           
            if(other.gameObject.tag=="hizarttir")
            {
                faster.Play();
                 Vector3 kuvvetbaslangıc=new Vector3(0,0,1000000f);   //300000f 
             rb.AddForce(kuvvetbaslangıc);
              Destroy(other.gameObject);
             
                
            }

            if(other.gameObject.tag=="hizazalt")
            {
                Vector3 kuvvetbaslangıc=new Vector3(0,0,-1000000f);
            rb.AddForce(kuvvetbaslangıc);
              Destroy(other.gameObject);
                
            }

            if(other.gameObject.name=="SON_1")
            {
                yol2.position = new Vector3(yol1.position.x,yol1.position.y,yol1.position.z);
            }

            if(other.gameObject.name=="SON_2")
            {
                yol1.position = new Vector3(yol2.position.x,yol2.position.y,yol2.position.z+400.0f);
            }
        }

            private void UpdateWheels()
    {
        UpdateWheelPos(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateWheelPos(frontRightWheelCollider, frontRightWheelTransform);
        UpdateWheelPos(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateWheelPos(rearRightWheelCollider, rearRightWheelTransform);
    }

    private void UpdateWheelPos(WheelCollider wheelCollider, Transform trans)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        trans.rotation = rot;
        trans.position = pos; 

    }

    
    

}
