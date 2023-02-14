using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCamShake : MonoBehaviour
{
    Vector3 OriginalPosition;
    public int RandomX;
    public int RandomY;
    public float OrginX;
    public float OrginY;
    public float OrginZ;

    
    
    // Start is called before the first frame update
    void Start()
    {
        OriginalPosition = transform.localPosition;
        OrginX = OriginalPosition.x;
        OrginY = OriginalPosition.y;
        OrginZ = OriginalPosition.z;

        //Assignar OriginalPosition's Vector3 till kamerans nuvarande Vector3. Sedan assignas varje axel v�rde till dess respektive Orgin v�rde.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScreenShaking()
    {
        print("SCREEN IS SHAKING");
        RandomX = Random.Range(-1, 2);
        if (RandomX == 0)
        {
            RandomX = Random.Range(-1, 2);
        }

        else
        {
            transform.localPosition += new Vector3(RandomX * 0.25f, RandomY * 0.25f);
        }

        RandomY = Random.Range(-1, 2);
        if (RandomY == 0)
        {
            RandomY = Random.Range(-1, 2);
        }

        else
        {
            transform.localPosition += new Vector3(RandomX * 0.25f, RandomY * 0.25f);
        }

        //En funktion som n�r aktiverad v�ljer ett nummer mellan -1 och 2, vilket blir ett v�rde mellan -1 och 1 d� 2 exluderas. 
        //Blir v�rdet 0 v�ljs v�rdet om. 
        //Random v�rdet v�ljer ett v�rde till X och Y. Sedan �ndras kamerans position beroende p� vad v�rdet blir. 
    }

    public void ScreenReset()
    {
        transform.localPosition = new Vector3(OrginX, OrginY, OrginZ);

        //N�r funktionen ScreenReset aktiveras s� �ndras kamerans nuvarande position till dess ursprungliga position.
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BossCamBorder")
        {
            print("Weewoo");
            ScreenReset();

            //Om kameran r�r ett objekt med tagen "BossCamBorder" s� �ndras positionen till dess ursprungliga position. 
            //Objekten med tagen "BossCamBorder" f�rhindrar kameran fr�n att flytta sig mer �n vad BossCamBorder objekten till�ter. 


        }
    }

    //Victor's script.
}
