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

            //N�r spelaren r�r "CamSwitcher3" objektet s� byts kamrean fr�n BossCam till BossCam2 vilket ger ett h�gre perspektiv av Boss Arenan.
            //Bossen b�rjar sikta in sig p� target stenarna i den �vre delen och slutar sikta in sig p� stenarna i den undre delen av boss arenan

        }
    }

    //Victor's script.
}
