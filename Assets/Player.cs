using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 10, 0) * Time.deltaTime;
        }

        if  (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-15, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
                transform.position += new Vector3(0, -5, 0) * Time.deltaTime;
           }


        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(15, 0, 0) * Time.deltaTime;
        }


        
        

        



    }
}
