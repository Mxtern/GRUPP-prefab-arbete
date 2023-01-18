using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehaviour : MonoBehaviour
{
    public Rigidbody2D Rb2;

    

    
    // Start is called before the first frame update
    void Start()
    {
        
        Rb2 = GetComponent<Rigidbody2D>();
        Rb2.AddForce(transform.right * 500);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Destroy(this.gameObject, 4.15f);
        }
    }
    
}
