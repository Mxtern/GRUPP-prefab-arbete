using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D Rb2;

    public bool OnFloor;
    public bool AirDashCD;
    public bool RunCD;
    public bool Sliding;

    public GameObject PlayerCamera;
    public GameObject EntranceCam;
    public GameObject BossCam;
    public GameObject Boss;

    [SerializeField]
    public float JumpForce = 340;

    // Start is called before the first frame update
    void Start()
    {
        Rb2 = GetComponent<Rigidbody2D>();
        PlayerCamera.SetActive(true);
        EntranceCam.SetActive(false);
        BossCam.SetActive(false);
        Boss.SetActive(false);
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

        if (Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.LeftShift) && Rb2.velocity.x > -6)&&RunCD == false)
        {
            print("Running Left");
            
            Rb2.AddForce(new Vector3(-3, 0, 0));
        }
        else if (Input.GetKey(KeyCode.A) && Rb2.velocity.x > -3)
        {
            Rb2.AddForce(new Vector3(-3, 0, 0));
            
        }

        if (OnFloor == false && Input.GetKeyDown(KeyCode.Space) && AirDashCD == false&& AirDashCD == false && Input.GetKey(KeyCode.D))
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
        }


        /*if (OnFloor == true && Input.GetKey(KeyCode.C) && Rb2.velocity.x < -5)
        {
            Sliding = true;
            gameObject.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 0.5f, transform.localScale.z);
            Rb2.AddForce(new Vector3(-6, 0, 0));

            if (false)
            {
                gameObject.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 0.5f, transform.localScale.z);
                Sliding = false;
            }
            else if (Rb2.velocity.x < -2)
            {
                gameObject.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 0.5f, transform.localScale.z);
                Sliding = false;
            }

        }
        if (OnFloor == true && Input.GetKey(KeyCode.C) && Rb2.velocity.x > 5)
        {
            Sliding = true;
            gameObject.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 0.5f, transform.localScale.z);
            Rb2.AddForce(new Vector3(6, 0, 0));

            if (false)
            {
                gameObject.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 0.5f, transform.localScale.z);
                Sliding = false;
            }
            else if (Rb2.velocity.x < 2)
            {
                gameObject.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 0.5f, transform.localScale.z);
                Sliding = false;
            }
        } */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            OnFloor = true;
            AirDashCD = false;
            RunCD = false;
        }

        /*if (collision.gameObject.tag == "CamSwticher1")
        {
            print("Switch");
            PlayerCamera.SetActive(false);
            EntranceCam.SetActive(true);
            BossCam.SetActive(false);
        }
        if (collision.gameObject.tag == "CamSwticher2")
        {
            print("Switch2");
            PlayerCamera.SetActive(false);
            EntranceCam.SetActive(false);
            BossCam.SetActive(true);
        }*/

    }

    public void Detected()
    {
        Destroy(this.gameObject);
    }

}
