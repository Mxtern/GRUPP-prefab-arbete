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

        //Assignar OriginalPosition's Vector3 till kamerans nuvarande Vector3. Sedan assignas varje axel värde till dess respektive Orgin värde.
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

        //En funktion som när aktiverad väljer ett nummer mellan -1 och 2, vilket blir ett värde mellan -1 och 1 då 2 exluderas. 
        //Blir värdet 0 väljs värdet om. 
        //Random värdet väljer ett värde till X och Y. Sedan ändras kamerans position beroende på vad värdet blir. 
    }

    public void ScreenReset()
    {
        transform.localPosition = new Vector3(OrginX, OrginY, OrginZ);

        //När funktionen ScreenReset aktiveras så ändras kamerans nuvarande position till dess ursprungliga position.
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BossCamBorder")
        {
            print("Weewoo");
            ScreenReset();

            //Om kameran rör ett objekt med tagen "BossCamBorder" så ändras positionen till dess ursprungliga position. 
            //Objekten med tagen "BossCamBorder" förhindrar kameran från att flytta sig mer än vad BossCamBorder objekten tillåter. 


        }
    }

    //Victor's script.
}
