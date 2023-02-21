using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    

    public Transform FollowStones = null; //Hittar positionen av bossens Target.
    public Transform FollowPlayer = null; //Hittar positionen av spelaren.

    public bool PlayerDeath;

    public float TimeUntilRespawn = 5.0f;
    public float TimeLeft;
    Rigidbody2D Rb2;
    // Start is called before the first frame update
    void Start()
    {
        Rb2.GetComponent<Rigidbody2D>();
        PlayerDeath = false;

    }

    // Update is called once per frame
    void Update()
    {
        
        this.transform.LookAt(FollowStones); 
        transform.right = FollowStones.position - transform.position; 

        if (PlayerDeath == true)
        {
            TimeLeft += Time.deltaTime;
            if (TimeLeft == 1)
            {
                TimeUntilRespawn += TimeLeft;
            }
            else if (TimeUntilRespawn < TimeLeft)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            //Roterar bossens sikte s� att den alltid kollar mot Targeten.
        }
    }
    public void RestartGame()
    {
        PlayerDeath = true;

        //En funktion som aktiverar PlayerDeath boolen.
    }

    //Victor's script.
}
