using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStart : MonoBehaviour //Det h�r scriptet inleder boss fighten.
{
    public GameObject BossOpening; //D�ligt namn, men BossOpening �r Bossens 
    public GameObject SleepingHarvester;
    public GameObject SneakArea;
<<<<<<< HEAD
    // Start is called before the first frame update
    void Start()
    {
        
=======

    public GameObject FearMessage;
    public bool ConstantShakeScreen;
    // Start is called before the first frame update
    void Start()
    {
        ConstantShakeScreen = false;
        FearMessage.SetActive(false);
<<<<<<< Updated upstream
=======
>>>>>>> d90f69c06657799a0df4549f17f8d8a8ebdf2d69
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        
    }
    public void DestroyIntro()
    {
        Destroy(this.gameObject);
=======
        if (ConstantShakeScreen == true)
        {
            FindObjectOfType<BossCamShake>().ScreenShaking();
        }

        //Om boolen "ConstantShakeScreen" �r sann s� aktiveras "ScreenShake" funktionen i BossCamShake, vilket konstant skakar sk�rmen tills n�gon f�rhindrar den exempelvist om ConstantShakeScreen skulle st�llas som falsk.
    }
    public void DestroyIntro()
    {
        ConstantShakeScreen = false;
        if (ConstantShakeScreen == false)
        {
            FindObjectOfType<BossCamShake>().ScreenReset();
            Destroy(this.gameObject);
        }
        
        //Funktionen st�nger av ConstantShakeScreen vilket st�nger av sk�rm skakningen, om ConstantScreenShake sedan �r av s� �ndras boss kamerans position till dess ursprungliga position och objektet som startar boss fighten f�rst�rs.
<<<<<<< Updated upstream
=======
>>>>>>> d90f69c06657799a0df4549f17f8d8a8ebdf2d69
>>>>>>> Stashed changes
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("As The Rubble Starts To Move, Your Veins Fills With Adrenaline.");
            FearMessage.SetActive(true);
            BossOpening.SetActive(true);
            FindObjectOfType<EnemyBehaviour>().WaitAndStart();
            FindObjectOfType<PlayerMovement>().Fear();
            SneakArea.SetActive(true);
            SleepingHarvester.SetActive(false);

            //Om spelaren r�r objektet som startar boss fighten s� aktiveras BossOpening vilket startas bossens animationer. F�rst st�ller sig bossen up och sedan hamnar den i en loop av bossens idle animation.
            //Samdigit kallas skript fr�n EnemyBehaviour och PlayerMovement som s�tter spelaren i ett "FearState" l�ge som g�r s� att den ej kan springa eller dasha. Dessutom Aktiveras en timer som s�tter p� och st�nger av boss opening och sj�vla boss fighten.
            //SneakArea aktiveras vilket inneb�r att ett omr�de d�r du ej kan springa eller dasha dycker up i en viss del av boss arenan.
            //Spriten som ska likna en deaktiverad harvester st�ngs av och byts ut av den aktiva boss spriten.
            //ConstantShakeScreen s�tts p�, vilket ska visualisera att marken skakar n�r boss opening startar dvs n�r bossen st�ller sig up.
        }

        //Victor's script.
    }

}
