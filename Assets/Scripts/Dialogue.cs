using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    bool Player;
    bool newsPaper;
    bool newsPaperDialogue;

    bool isActiveAndEnabled;
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
        if (collision.gameObject.tag=="newsPaper")
        {
            newsPaperDialogue = isActiveAndEnabled = true;
        }
    }

}
