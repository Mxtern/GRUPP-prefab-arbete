using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorBehaviour : MonoBehaviour
{
    public bool IsHiding;
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
            print("You Have Been Detected.");
            FindObjectOfType<PlayerMovement>().Detected();
        }
        else if (collision.gameObject.tag == "HidingPlayer")
        {
            print("Player is hiding");
        }
    }
}
