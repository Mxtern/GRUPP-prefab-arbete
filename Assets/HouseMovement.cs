using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HouseMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D Rb2;

    public bool OnFloor;
    public bool AirDashCD;
    public bool RunCD;
    public bool Sliding;
    public bool FearState;
    public bool HasRock;
    public bool Moving;


    public GameObject PlayerCamera;
    public GameObject EntranceCam;
    public GameObject BossCam;
    public GameObject Boss;
    public GameObject BossOpening;
    public GameObject TargetManager;


    public Animator PlayerAniamtion;
    [SerializeField]
    public float JumpForce = 340.0f;

    [SerializeField]
    public float LeftWalkSpeed = -6.0f;

    [SerializeField]
    public float RightWalkSpeed = 6.0f;

    [SerializeField]
    public float DashSpeed = 300.0f;

    // Start is called before the first frame update
    void Start()
    {
        Rb2 = GetComponent<Rigidbody2D>();

        PlayerCamera.SetActive(true);
        EntranceCam.SetActive(false);
        BossCam.SetActive(false);
        Boss.SetActive(false);
        BossOpening.SetActive(false);
        TargetManager.SetActive(false);
        Moving = false;
        gameObject.tag = "Player";

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Rb2.velocity.x > 0)
        {
            PlayerAniamtion.SetBool("IsWalking", true);

        }
        else if (Rb2.velocity.x == 0)
        {
            PlayerAniamtion.SetBool("IsWalking", false);
        }

        if (Rb2.velocity.x < 0)
        {
            PlayerAniamtion.SetBool("IsWalking", true);

        }
        else if (Rb2.velocity.x == 0)
        {
            PlayerAniamtion.SetBool("IsWalking", false);
        }

        if (Rb2.velocity.y == 0)
        {
            PlayerAniamtion.SetBool("IsJumping", false);
            PlayerAniamtion.SetBool("IsFalling", false);
        }
        else if (Rb2.velocity.y > 0)
        {
            PlayerAniamtion.SetBool("IsJumping", true);
            PlayerAniamtion.SetBool("IsFalling", false);
        }
        else if (Rb2.velocity.y < 0)
        {
            PlayerAniamtion.SetBool("IsJumping", false);
            PlayerAniamtion.SetBool("IsFalling", true);
        }




        if (Input.GetKeyDown(KeyCode.W) && OnFloor == true && FearState == false)
        {
            print("Jump");
            Rb2.AddForce(new Vector3(0, JumpForce, 0));
            OnFloor = false;
            if (OnFloor == false)
            {

            }
        }

        if (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.LeftShift)) && RunCD == false && FearState == false)
        {
            print("Running Right");
            Moving = true;

            Rb2.AddForce(new Vector3(RightWalkSpeed, 0, 0));
            if (Rb2.velocity.x > 3.0f)
            {
                Rb2.velocity = new Vector2(3.0f, Rb2.velocity.y);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Moving = true;
            Rb2.AddForce(new Vector3(RightWalkSpeed, 0, 0));
            if (Rb2.velocity.x > 1.5f)
            {
                Rb2.velocity = new Vector2(1.5f, Rb2.velocity.y);
            }

        }
        else
        {
            Moving = false;
        }
        if (Moving == false)
        {
            Rb2.velocity = new Vector2(0.0f, Rb2.velocity.y);
        }


        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift) && RunCD == false && FearState == false)
        {
            print("Running Left");
            /*FindObjectOfType<RotateSurvivor>().Rotate180();*/
            Moving = true;
            Rb2.AddForce(new Vector3(LeftWalkSpeed, 0, 0));
            if (Rb2.velocity.x < -3.0f)
            {
                Rb2.velocity = new Vector2(-3.0f, Rb2.velocity.y);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            /*FindObjectOfType<RotateSurvivor>().Rotate180();*/
            Moving = true;
            Rb2.AddForce(new Vector3(LeftWalkSpeed, 0, 0));
            if (Rb2.velocity.x < -1.5f)
            {
                Rb2.velocity = new Vector2(-1.5f, Rb2.velocity.y);
            }

        }
        else
        {
            Moving = false;
        }



        if (OnFloor == false && Input.GetKeyDown(KeyCode.Space) && AirDashCD == false && AirDashCD == false && Input.GetKey(KeyCode.D))
        {
            Rb2.AddForce(new Vector3(DashSpeed, 0, 0));
            AirDashCD = true;
            RunCD = true;
        }
        if (OnFloor == false && Input.GetKeyDown(KeyCode.Space) && AirDashCD == false && AirDashCD == false && Input.GetKey(KeyCode.A))
        {
            Rb2.AddForce(new Vector3(-DashSpeed, 0, 0));
            AirDashCD = true;
            RunCD = true;
        }

        if (HasRock == true)
        {
            FindObjectOfType<ShootBehaviour>().ThrowRock();


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



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HidingPlace")
        {
            gameObject.tag = "HidingPlayer";
        }
        if (collision.gameObject.tag == "StopHiding")
        {
            gameObject.tag = "Player";
        }




    }
    public void Rock()
    {
        HasRock = true;
    }
    public void Fear()
    {
        FearState = true;
    }

    public void Detected()
    {
        FindObjectOfType<TargetMove>().DisableTargetPicking();
        FindObjectOfType<TargetStone>().SwitchTargets();
        Destroy(this.gameObject, 3.0f);


    }

}
