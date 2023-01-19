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
    public bool FearState;
    public bool HasRock;
    public bool MovingRight;
    public bool MovingLeft;
    

    public GameObject PlayerCamera;
    public GameObject HouseCam;
    public GameObject EntranceCam;
    public GameObject BossCam;
    public GameObject Boss;
    public GameObject BossOpening;
    public GameObject TargetManager;
    

    public Animator PlayerAniamtion;
    [SerializeField]
    public float JumpForce = 340.0f;

    [SerializeField]
    public float LeftWalkSpeed = -2.0f;

    [SerializeField]
    public float RightWalkSpeed = 2.0f;

    [SerializeField]
    public float LeftRunSpeed = -5.0f;

    [SerializeField]
    public float RightRunSpeed = 5.0f;

    [SerializeField]
    public float DashSpeed = 300.0f;



    // Start is called before the first frame update
    void Start()
    {
        
        Rb2 = GetComponent<Rigidbody2D>();
        HouseCam.SetActive(false); //change later
        PlayerCamera.SetActive(true);
        EntranceCam.SetActive(false);
        BossCam.SetActive(false);
        Boss.SetActive(false);
        BossOpening.SetActive(false);
        TargetManager.SetActive(false);
        MovingLeft = false;
        MovingRight = false;
        gameObject.tag = "Player";
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        if (Rb2.velocity.x > 0)
        {
            PlayerAniamtion.SetBool("IsWalking", true);
            FindObjectOfType<RotateSurvivor>().FlipPlayerRight();
            
        }
        else if (Rb2.velocity.x == 0)
        {
            PlayerAniamtion.SetBool("IsWalking", false);
            
            
        }

        if (Rb2.velocity.x < 0)
        {
            PlayerAniamtion.SetBool("IsWalking", true);
            FindObjectOfType<RotateSurvivor>().FlipPlayerLeft();

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




        if (Input.GetKeyDown(KeyCode.W) && OnFloor == true &&FearState == false)
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
            MovingRight = true;
            
            Rb2.AddForce(new Vector2(100.0f, Rb2.velocity.y));
            if (Rb2.velocity.x > RightRunSpeed)
            {
                Rb2.velocity = new Vector2(RightRunSpeed, Rb2.velocity.y);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MovingRight = true;
            Rb2.AddForce(new Vector2(100.0f, Rb2.velocity.y));
            if (Rb2.velocity.x > RightWalkSpeed)
            {
                Rb2.velocity = new Vector2(RightWalkSpeed, Rb2.velocity.y);
            }

        }
        else 
        {
            MovingRight = false;
        }



        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift) && RunCD == false && FearState == false)
        {
            print("Running Left");
            MovingLeft = true;
            Rb2.AddForce(new Vector2(-100, Rb2.velocity.y));
            if (Rb2.velocity.x < LeftRunSpeed)
            {
                Rb2.velocity = new Vector2(LeftRunSpeed, Rb2.velocity.y);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            MovingLeft = true;
            Rb2.AddForce(new Vector2(-100, Rb2.velocity.y));
            if (Rb2.velocity.x < LeftWalkSpeed)
            {
                Rb2.velocity = new Vector2(LeftWalkSpeed, Rb2.velocity.y);
            }

        }
        else
        {
            MovingLeft = false;
        }
        


        if (OnFloor == false && Input.GetKeyDown(KeyCode.Space) && AirDashCD == false&& AirDashCD == false && Input.GetKey(KeyCode.D))
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

        if (MovingLeft == false)
        {

            Rb2.velocity = new Vector2(0.0f, Rb2.velocity.y);
        }
        if (MovingRight == false)
        {
            Rb2.velocity = new Vector2(0.0f, Rb2.velocity.y);
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
