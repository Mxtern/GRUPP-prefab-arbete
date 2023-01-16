using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject Boss;
    public GameObject BossOpening;
    public GameObject TargetManager;

    [SerializeField]
    public float BossCutscene = 3.0f;
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
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    public void WaitAndStart()
    {
        BossCountdown = true;
        
    }

    public void BossSequenceStart()
    {
        Destroy(BossOpening.gameObject);
        FindObjectOfType<BossStart>().DestroyIntro();
        TargetManager.SetActive(true);
        BossCountdown = (false);
        Boss.SetActive(true);
    }
}
