using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class klon_olustur : MonoBehaviour
{
    
    public GameObject benzin;
    public GameObject bomba;

    public Transform Cube;
    public Transform yol1;
    public Transform yol2;
    
    float silinme_zamani=10f;
    public float sag_X_koordinat=10f;
    public float sol_X_koordinat=-10f;
    void Start()
    {
        InvokeRepeating("nesne_klonla",0,2f);
    }
    
    

    void Update()
    {
        
    }

    void nesne_klonla()
    {
        int rastsayi=Random.Range(0,100);
        if(rastsayi>0 && rastsayi<50)
        {
            klonla(benzin,1.0f);
        }

        if(rastsayi>50 && rastsayi<100)
        {
            klonla(bomba,3.0f);
        }
        
    }

    void klonla(GameObject nesne,float Y_koordinat)
    {
        GameObject yeni_klon =Instantiate(nesne);

        int rastsayi=Random.Range(0,100);

        if(rastsayi<50)
        {
            yeni_klon.transform.position=new Vector3(sag_X_koordinat,Y_koordinat,Cube.position.z+200.0f);
        }

        else if(rastsayi>50)
        {
            yeni_klon.transform.position=new Vector3(sol_X_koordinat,Y_koordinat,Cube.position.z+200.0f);
        }

        Destroy(yeni_klon,silinme_zamani);
    }
}
