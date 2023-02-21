using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Pickup : MonoBehaviour
{
    public GameObject PickupText;

    public bool PickupAvalible;
    public Vector3 StonePos;
    // Start is called before the first frame update
    void Start()
    {
        PickupAvalible = false;
        PickupText.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PickupAvalible == true)
        {
            PickupText.SetActive(true);
        }
        if (PickupAvalible == false)
        {
            PickupText.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.F) && PickupAvalible == true)
        {
            FindObjectOfType<PlayerMovement>().HasRock = true;
            Destroy(this.gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && FindObjectOfType<PlayerMovement>().HasRock == false)
        {
            StonePos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2.5f, gameObject.transform.position.z);
            PickupAvalible = true;
            PickupText.transform.position = StonePos;
            
            //Om spelaren står vid en sten så visas en pickup icon som indikerar att man kan trycka på F för att ta up stenen.
        }
        

        //Picks up rock when player is touching the rock and presses F.
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PickupAvalible = false;

            //Tar bort pickup iconen om man inte längre står vid stenen.
        }
    }

    //Victor's script.
}
