using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject Boss;
    public GameObject TargetManager;

    [SerializeField]
    public float BossCutscene = 5.0f;
    public float TimeLeft;
    public bool BossCountdown = false;

    Rigidbody2D Rb2;
    // Start is called before the first frame update
    void Start()
    {
       Rb2 = GetComponent<Rigidbody2D>();
       TimeLeft = BossCutscene;
    }

    // Update is called once per frame
    void Update()
    {
        if (BossCountdown == true)
        {
            TimeLeft -= (1 * Time.deltaTime);
            if (TimeLeft <= 0.0f)
            {
                BossSequenceStart();
            }

            //Startar en nedräkning som efter 5 sekunder  startar själva boss fighten.
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    public void WaitAndStart()
    {
        BossCountdown = true;
        
        //Sätter BossCountdown till true. 
    }

    public void BossSequenceStart()
    {
        
        FindObjectOfType<BossStart>().DestroyIntro();
        TargetManager.SetActive(true);
        BossCountdown = (false);
        Boss.SetActive(true);

        //Funktionen avslutar boss openingen och startar sjävla boss fighten.
    }

    //Victor's script.
}

