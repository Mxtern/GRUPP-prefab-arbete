using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public bool PlayerDetected;

    public GameObject Enemy;
    Rigidbody2D Rb2;
    // Start is called before the first frame update
    void Start()
    {
       Rb2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    public void WaitAndStart()
    {

    }

}
