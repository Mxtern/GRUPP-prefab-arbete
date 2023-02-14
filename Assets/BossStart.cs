using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStart : MonoBehaviour //Det här scriptet inleder boss fighten.
{
    public GameObject BossOpening; //Dåligt namn, men BossOpening är Bossens 
    public GameObject SleepingHarvester;
    public GameObject SneakArea;

    public bool ConstantShakeScreen;
    // Start is called before the first frame update
    void Start()
    {
        ConstantShakeScreen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ConstantShakeScreen == true)
        {
            FindObjectOfType<BossCamShake>().ScreenShaking();
        }
    }
    public void DestroyIntro()
    {
        ConstantShakeScreen = false;
        if (ConstantShakeScreen == false)
        {
            FindObjectOfType<BossCamShake>().ScreenReset();
            Destroy(this.gameObject);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("As The Rubble Starts To Move, Your Veins Fills With Adrenaline.");
            BossOpening.SetActive(true);
            FindObjectOfType<EnemyBehaviour>().WaitAndStart();
            FindObjectOfType<PlayerMovement>().Fear();
            SneakArea.SetActive(true);
            SleepingHarvester.SetActive(false);
            ConstantShakeScreen = true;

        }
    }
    
}
