using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera1Behaviour : MonoBehaviour
{
    public GameObject PlayerCam;
    public GameObject EntranceCam;

    public bool EntranceCamActive;
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
            print("Enter");
            PlayerCam.SetActive(false);
            EntranceCam.SetActive(true);
        }

        //Om spelaren rör vid CamSwitcher1 så byts spelarens kamera från PlayerCam till EntranceCam, då PlayerCam stängs av samtidigt som EntranceCam sätts på.
    }

    //Victor's script.
}
