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

            //När spelaren rör "CamSwitcher3" objektet så byts kamrean från BossCam till BossCam2 vilket ger ett högre perspektiv av Boss Arenan.
            //Bossen börjar sikta in sig på target stenarna i den övre delen och slutar sikta in sig på stenarna i den undre delen av boss arenan

        }
    }

    //Victor's script.
}
