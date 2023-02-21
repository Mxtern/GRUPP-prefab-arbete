using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStart : MonoBehaviour //Det här scriptet inleder boss fighten.
{
    public GameObject BossOpening; //Dåligt namn, men BossOpening är Bossens 
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

        //Om boolen "ConstantShakeScreen" är sann så aktiveras "ScreenShake" funktionen i BossCamShake, vilket konstant skakar skärmen tills någon förhindrar den exempelvist om ConstantShakeScreen skulle ställas som falsk.
    }
    public void DestroyIntro()
    {
        ConstantShakeScreen = false;
        if (ConstantShakeScreen == false)
        {
            FindObjectOfType<BossCamShake>().ScreenReset();
            Destroy(this.gameObject);
        }
        
        //Funktionen stänger av ConstantShakeScreen vilket stänger av skärm skakningen, om ConstantScreenShake sedan är av så ändras boss kamerans position till dess ursprungliga position och objektet som startar boss fighten förstörs.
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

            //Om spelaren rör objektet som startar boss fighten så aktiveras BossOpening vilket startas bossens animationer. Först ställer sig bossen up och sedan hamnar den i en loop av bossens idle animation.
            //Samdigit kallas skript från EnemyBehaviour och PlayerMovement som sätter spelaren i ett "FearState" läge som gör så att den ej kan springa eller dasha. Dessutom Aktiveras en timer som sätter på och stänger av boss opening och sjävla boss fighten.
            //SneakArea aktiveras vilket innebär att ett område där du ej kan springa eller dasha dycker up i en viss del av boss arenan.
            //Spriten som ska likna en deaktiverad harvester stängs av och byts ut av den aktiva boss spriten.
            //ConstantShakeScreen sätts på, vilket ska visualisera att marken skakar när boss opening startar dvs när bossen ställer sig up.
        }

        //Victor's script.
    }

}
