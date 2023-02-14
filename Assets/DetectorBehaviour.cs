using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorBehaviour : MonoBehaviour
{// Victor
    public bool IsHiding;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void OnTriggerStay2D(Collider2D collision) //Stay innebär att den kollar efter trigger varje frame. 
    {
        

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("You Have Been Detected.");
            FindObjectOfType<PlayerMovement>().Detected();

            //Om Detectorn nuddar spelaren så aktiveras "Detected" funktionen i PlayerMovement. 
        }
        else if (collision.gameObject.tag == "HidingPlayer")
        {
            print("Player is hiding");

            //Om detectorn nuddar spelaren medans den gömmer sig så händer inget.
        }

        if (collision.gameObject.tag == "StonePrefab")
        {
            print("Distracted");
            FindObjectOfType<TargetMove>().Distracted();
            FindObjectOfType<TargetStone>().HarvesterDistracted(collision.transform);
        }
        
        //Om detectorn nuddar ett objekt med "StonePrefab" taggen så kallas Distracted och HarvesterDistractet funktionerna i TargetMove och TargetStone scripten. 
    }

    //Victor's script.
}
