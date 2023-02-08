using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera3Behaviour : MonoBehaviour
{
    public GameObject BossCam;
    public GameObject BossCam2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            BossCam.SetActive(false);
            BossCam2.SetActive(true);
            FindObjectOfType<TargetMove>().TargetUp = true;
            FindObjectOfType<TargetMove>().TargetLow = false;

        }
    }
}
