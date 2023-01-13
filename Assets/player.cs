using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(6, 0, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-6, 0, 0) * Time.deltaTime;
        }

       

        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += new Vector3(0, 6, 0) * Time.deltaTime;
        }

        


    }
   
}


 
