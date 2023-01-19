using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement2 : MonoBehaviour
{
    public Rigidbody2D Rb2;

    public bool OnFloor;
    public bool AirDashCD;
    public bool RunCD;

    [SerializeField]
    public float JumpForce = 100;


    private Vector3 respawnPoint;
    public GameObject fallDetector;

    // Start is called before the first frame update
    void Start()
    {
        Rb2 = GetComponent<Rigidbody2D>();

        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && OnFloor == true)
        {
            print("Jump");
            Rb2.AddForce(new Vector3(0, JumpForce, 0));
            OnFloor = false;
        }

        if (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.LeftShift) && Rb2.velocity.x < 6) && RunCD == false)
        {
            print("Running Right");
            Rb2.AddForce(new Vector3(3, 0, 0));
        }
        else if (Input.GetKey(KeyCode.D) && Rb2.velocity.x < 3)
        {
            Rb2.AddForce(new Vector3(3, 0, 0));
        }

        if (Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.LeftShift) && Rb2.velocity.x > -6) && RunCD == false)
        {
            print("Running Left");
            Rb2.AddForce(new Vector3(-3, 0, 0));
        }
        else if (Input.GetKey(KeyCode.A) && Rb2.velocity.x > -3)
        {
            Rb2.AddForce(new Vector3(-3, 0, 0));
        }

        if (OnFloor == false && Input.GetKeyDown(KeyCode.Space) && AirDashCD == false && AirDashCD == false && Input.GetKey(KeyCode.D))
        {
            Rb2.AddForce(new Vector3(300, 0, 0));
            AirDashCD = true;
            RunCD = true;
        }
        if (OnFloor == false && Input.GetKeyDown(KeyCode.Space) && AirDashCD == false && AirDashCD == false && Input.GetKey(KeyCode.A))
        {
            Rb2.AddForce(new Vector3(-300, 0, 0));
            AirDashCD = true;
            RunCD = true;


            fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "falldetector")
        {
            transform.position = respawnPoint;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            OnFloor = true;
            AirDashCD = false;
            RunCD = false;
        }
    }
}
