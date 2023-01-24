using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    

    public Transform FollowStones = null;
    public Transform FollowPlayer = null;

    public bool PlayerDeath;

    public float TimeUntilRespawn = 3.0f;
    public float TimeLeft;
    // Start is called before the first frame update
    void Start()
    {
        
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

        }
    }
    public void RestartGame()
    {
        PlayerDeath = true;

    }


}
