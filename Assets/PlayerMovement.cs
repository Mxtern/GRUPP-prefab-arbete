using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
    public bool CanRun;
    
    

    public GameObject PlayerCamera;
    public GameObject EntranceCam;
    public GameObject Boss;
    public GameObject BossCam;
    public GameObject BossCam2;
    public GameObject BossOpening;
    public GameObject TargetManager;
    public GameObject SneakArea;

    public int SwitchedScene = 1;

    public GameObject FinishGame;
    public Animator PlayerAniamtion;
    [SerializeField]
    public float JumpForce = 340.0f;

    [SerializeField]
    public float LeftWalkSpeed = -1.0f;

    [SerializeField]
    public float RightWalkSpeed = 1.0f;

    [SerializeField]
    public float LeftRunSpeed = -3.0f;

    [SerializeField]
    public float RightRunSpeed = 3.0f;

    [SerializeField]
    public float DashSpeed = 200.0f;



    // Start is called before the first frame update
    void Start() //Avaktiverar olika kameror när som ska aktiveras senare i spelet. Detta görs vid startet av spelet.
    {
        
        Rb2 = GetComponent<Rigidbody2D>();
        SneakArea.SetActive(false);
        PlayerCamera.SetActive(true);
        EntranceCam.SetActive(false);
        BossCam.SetActive(false);
        BossCam2.SetActive(false);
        Boss.SetActive(false);
        BossOpening.SetActive(false);
        TargetManager.SetActive(false);
        MovingLeft = false;
        MovingRight = false;
        CanRun = true;
        gameObject.tag = "Player"; //Objektet som har blivit tilldelad denna kod får även game tagen "Player".

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            FindObjectOfType<RotateSurvivor>().FlipPlayerLeft();

            //Trycker jag på A för att gå till vänster så byter player spriten dess riktning till vänster.
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            FindObjectOfType<RotateSurvivor>().FlipPlayerRight();

            //Samma sak som förra fast att spelar spriten roterar åt höger om man håller in D.
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            //Manualt respawnar.
        }


        


        if (Rb2.velocity.x > 0)
        {
            PlayerAniamtion.SetBool("IsWalking", true);
            FindObjectOfType<RotateSurvivor>().FlipPlayerRight(); 

            //Om din x velocity är över 0, dvs om du rör dig åt höger så spelas spritens walking animation samt roterar den åt höger.
        }

        else if (Rb2.velocity.x == 0)
        {
            PlayerAniamtion.SetBool("IsWalking", false);
            
            //Om din velocity i x axeln är detsamma som 0, dvs om du inte rör dig alls åt något håll så spelas spelas inte Walking animationen.
        }

        if (Rb2.velocity.x < 0) 
        {
            PlayerAniamtion.SetBool("IsWalking", true);
            FindObjectOfType<RotateSurvivor>().FlipPlayerLeft();

            //Om din velocity i x axeln är under 0, dvs om du går mot vänster så spelas spelarspritens walking animation samtidigt som spriten vänder sig åt vänster.
        }
        else if (Rb2.velocity.x == 0)
        {
            PlayerAniamtion.SetBool("IsWalking", false);
            
            //Om du inte rör dig så spelas ej spelarspritens walking animation.
        }

        if (Rb2.velocity.y == 0)
        {
            PlayerAniamtion.SetBool("IsJumping", false);
            PlayerAniamtion.SetBool("IsFalling", false);

            //Om spelares velocity i y axeln är detsamma som 0, dvs spelaren varken hoppar eller faller så stängs hopp- och falling animationen av.
        }
        else if (Rb2.velocity.y > 1 && OnFloor == false)
        {
            PlayerAniamtion.SetBool("IsJumping", true);
            PlayerAniamtion.SetBool("IsFalling", false);

            //Om din velocity i y axeln är över 0 samtidigt som du ej är på golvet, dvs om du hoppar så spelas hopp animationen samt så stängs falling animationen av. 
        }
        else if (Rb2.velocity.y < -1&& OnFloor == false)
        {
            PlayerAniamtion.SetBool("IsJumping", false);
            PlayerAniamtion.SetBool("IsFalling", true);

            //Om din velocity i y axeln är under 0, dvs om du faller så spelar falling animationen samt stängs hopp animationen av. 
        }
        if (OnFloor == true)
        {
            PlayerAniamtion.SetBool("OnFloor", true);

            //Om du är på golvet så spelar idle animationen.
        }
        else if (OnFloor == false)
        {
            PlayerAniamtion.SetBool("OnFloor", false);

            //Om du inte är på golvet så stängs idle animationen av. 
        }

        //NOTE: ExampleAnimation.SetBool("ExampleBool", false eller true); Sätter inte på eller stänger av animationerna i sig själv, utan jag har skapat bools i animatören som använder sig av boolsen status för att välja om en viss animation ska spelas.
        //Exempelvist så kan animatören bara spela idle animationen om boolen "OnFloor" är sann. Därför om vi sätter att den boolen är sann när vi rör golvet så ser animatören att boolen är sann och i sin tur spelar up animationen. 



        if (Input.GetKeyDown(KeyCode.W) && OnFloor == true)
        {
            print("Jump");
            Rb2.AddForce(new Vector3(0, JumpForce, 0));
            OnFloor = false;
            
            //Om du trycker på W samtidigt som du är på golvet så hoppar du.
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift) && RunCD == false && FearState == false && CanRun == true)
        {
            print("Running Right");
            
            
            Rb2.AddForce(new Vector2(100.0f, Rb2.velocity.y));
            if (Rb2.velocity.x > RightRunSpeed)
            {
                Rb2.velocity = new Vector2(RightRunSpeed, Rb2.velocity.y);
            }

            //Håller du in Shift och D samtidigt, dvs om du håller in shift medan du går åt höger så springer du åt höger.
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MovingRight = true;
            if (AirDashCD == false)
            {
                Rb2.AddForce(new Vector2(100.0f, Rb2.velocity.y));
                if (Rb2.velocity.x > RightWalkSpeed)
                {
                    Rb2.velocity = new Vector2(RightWalkSpeed, Rb2.velocity.y);
                }
            }
            
            //Håller du nere D så rör du dig åt höger. 
        }
        else 
        {
            MovingRight = false;

            //Om du varken springer eller går åt höger så sätts boolen "MovingRight" till false.
        }



        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift) && RunCD == false && FearState == false && CanRun == true)
        {
            print("Running Left");

            Rb2.AddForce(new Vector2(-100, Rb2.velocity.y));
            if (Rb2.velocity.x < LeftRunSpeed)
            {
                Rb2.velocity = new Vector2(LeftRunSpeed, Rb2.velocity.y);
            }

            //Samma sak som hur man springer åt höger, fast nu åt vänster. Håller du in A och shift samtidigt så springer du åt vänster.
        }
        else if (Input.GetKey(KeyCode.A))
        {
            MovingLeft = true;
            if (AirDashCD == false)
            {
                Rb2.AddForce(new Vector2(-100, Rb2.velocity.y));
                if (Rb2.velocity.x < LeftWalkSpeed)
                {
                    Rb2.velocity = new Vector2(LeftWalkSpeed, Rb2.velocity.y);

                    //Håller du in A så rör du dig åt vänster.
                }
            }
            

        }
        else
        {
            MovingLeft = false;

            //Om du varken springer eller går mot höger så sätts boolen "MovingLeft" till false.
        }



        if (OnFloor == false && Input.GetKeyDown(KeyCode.Space) && AirDashCD == false && Input.GetKey(KeyCode.D) && FearState == false)
        {
            Rb2.AddForce(new Vector3(DashSpeed, 0, 0));
            AirDashCD = true;
            RunCD = true;
            print("Dashed Right");

            //Om du är i luften och trycker på space samtidigt som du håller nere D och din AirDash Cooldown ej är aktiv dvs att den är falsk så dashar du åt höger.
        }
        if (OnFloor == false && Input.GetKeyDown(KeyCode.Space) && AirDashCD == false && Input.GetKey(KeyCode.A) && FearState == false)
        {
            Rb2.AddForce(new Vector3(-DashSpeed, 0, 0));

            AirDashCD = true;
            RunCD = true;
            print("Dashed Left");

            //Samma sak fast åt vänster. För någon anledning fungerar bara höger dock.
        }

        if (HasRock == true)
        {
            FindObjectOfType<ShootBehaviour>().ThrowRock();
            
            //Om du har en sten så aktiveras ThrowRock() i ShootBehaviour scriptet. ThrowRock().
            //ThrowRock() Gör så att du kan kasta en sten, men för att kunna göra det måste du först ha en sten att kasta dvs din HasRock måste vara true.
        }

        if (MovingLeft == false && MovingRight == false)
        {
            Rb2.velocity = new Vector2(0.0f, Rb2.velocity.y);

            //Om du inte rör dig åt vänster så sätts din velocity i x axeln till 0. Detta förhindrar spelaren från att glida på golvet.
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            OnFloor = true;
            AirDashCD = false;
            RunCD = false;
            if (PlayerAniamtion.GetBool("IsFalling") == true && collision.gameObject.tag == "Floor")
            {
                PlayerAniamtion.SetBool("IsLanding", true);
                
            }
            else if (OnFloor == true && PlayerAniamtion.GetBool("OnFloor") == true)
            {
                PlayerAniamtion.SetBool("IsLanding", false);
            }
            PlayerAniamtion.SetBool("IsFalling", false);

        }
        else
        {
            OnFloor = false;
        }

        //När spelaren är på/nuddar marken så sätts boolen OnFloor till true samt AriDashCd och RunCD till false. 
        //OnFloor indikerar om och när du nuddar marken. Om du faller och sedan nuddar marken så spelas Landing animationen.
        //Nuddar du marken så spelas ej Falling animationen.
    }
    public void Rock()
    {
        HasRock = true;

        //När funktionen kallas så sätts boolen "HasRock" till true. 
        //Denna bool indikerar om karakätren har tagit upp en sten. Om karaktären har tagit upp en sten kan den ej göra det igen tills du kastar den första.
    }
    public void Fear()
    {
        FearState = true;

        //Funktionen sätter Boolen "FearState" till true. Om du är i ett FearState läge kan du ej Dasha.
    }

    public void Detected()
    {
        FindObjectOfType<TargetMove>().DisableTargetPicking();
        FindObjectOfType<TargetStone>().SwitchTargets();
        FindObjectOfType<BossBehaviour>().RestartGame();
        Destroy(this.gameObject, 5.0f);
        
        //Om funktionen Detected blir kallad så kallas 3 andra funktioner i olika script. 
        //Dessa funktioner gör så att Harvestern siktar in sig på splearen och när spelaren blivit detected så startar spelet om, dvs du respawnar.
        //5 sekunder efter du blivit hittad så dör du.
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FinishGame" && SwitchedScene == 1)
        {
            SceneManager.LoadScene("MainMenu");
            SwitchedScene += 1;
            
            //Om du klarar ut spelet och nuddar ett specifikt game object med tagen "FinishGame" så byts scenen tillbaks till menyn. 
        }

        if (collision.gameObject.tag == "SneakArea")
        {
            print("BE QUIET");
            FearState = true;
            CanRun = false;
            
            //Så länge spelaren är inne i "SneakArea" området så sätts FeatState som sann.
            //Om spelarens FearState är sann så kan den ej dasha.
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SneakArea")
        {
            print("u dont have to be quiet :>");
            FearState = false;
            CanRun = true;

            //När spelaren går ut från SneakArea området så byts spelarens FearState till false.
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HidingPlace")
        {
            gameObject.tag = "HidingPlayer";

            //Om spelaren är vid en stor sten eller ett gömställe så ändras dess tag till "HidingPlayer".
            //När spelaren har tagen "HidingPlayer" så kan Harvestern inte detecta dig.
        }
        else
        {
            gameObject.tag = "Player";

            //Om spelaren inte är vid en stor sten eller ett gömställe så har den sin normala tag, dvs "Player".
        }

        
    }
    
    //Victor's script.
}
