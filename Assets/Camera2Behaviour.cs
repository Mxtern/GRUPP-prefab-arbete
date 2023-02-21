using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2Behaviour : MonoBehaviour
{
    public GameObject EntranceCam;
    public GameObject BossCam;
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
            print("You Feel As If Someone Is Watching Over You..");
            EntranceCam.SetActive(false);
            BossCam.SetActive(true);

            //När spelaren nuddar "CamSwitcher2" objektet så byts kameran från EntranceCam till BossCam.
        }
    }
}
