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
    void Start() //Avaktiverar olika kameror n�r som ska aktiveras senare i spelet. Detta g�rs vid startet av spelet.
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
        gameObject.tag = "Player"; //Objektet som har blivit tilldelad denna kod f�r �ven game tagen "Player".

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            FindObjectOfType<RotateSurvivor>().FlipPlayerLeft();

            //Trycker jag p� A f�r att g� till v�nster s� byter player spriten dess riktning till v�nster.
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            FindObjectOfType<RotateSurvivor>().FlipPlayerRight();

            //Samma sak som f�rra fast att spelar spriten roterar �t h�ger om man h�ller in D.
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

            //Om din x velocity �r �ver 0, dvs om du r�r dig �t h�ger s� spelas spritens walking animation samt roterar den �t h�ger.
        }

        else if (Rb2.velocity.x == 0)
        {
            PlayerAniamtion.SetBool("IsWalking", false);
            
            //Om din velocity i x axeln �r detsamma som 0, dvs om du inte r�r dig alls �t n�got h�ll s� spelas spelas inte Walking animationen.
        }

        if (Rb2.velocity.x < 0) 
        {
            PlayerAniamtion.SetBool("IsWalking", true);
            FindObjectOfType<RotateSurvivor>().FlipPlayerLeft();

            //Om din velocity i x axeln �r under 0, dvs om du g�r mot v�nster s� spelas spelarspritens walking animation samtidigt som spriten v�nder sig �t v�nster.
        }
        else if (Rb2.velocity.x == 0)
        {
            PlayerAniamtion.SetBool("IsWalking", false);
            
            //Om du inte r�r dig s� spelas ej spelarspritens walking animation.
        }

        if (Rb2.velocity.y == 0)
        {
            PlayerAniamtion.SetBool("IsJumping", false);
            PlayerAniamtion.SetBool("IsFalling", false);

            //Om spelares velocity i y axeln �r detsamma som 0, dvs spelaren varken hoppar eller faller s� st�ngs hopp- och falling animationen av.
        }
        else if (Rb2.velocity.y > 1 && OnFloor == false)
        {
            PlayerAniamtion.SetBool("IsJumping", true);
            PlayerAniamtion.SetBool("IsFalling", false);

            //Om din velocity i y axeln �r �ver 0 samtidigt som du ej �r p� golvet, dvs om du hoppar s� spelas hopp animationen samt s� st�ngs falling animationen av. 
        }
        else if (Rb2.velocity.y < -1&& OnFloor == false)
        {
            PlayerAniamtion.SetBool("IsJumping", false);
            PlayerAniamtion.SetBool("IsFalling", true);

            //Om din velocity i y axeln �r under 0, dvs om du faller s� spelar falling animationen samt st�ngs hopp animationen av. 
        }
        if (OnFloor == true)
        {
            PlayerAniamtion.SetBool("OnFloor", true);

            //Om du �r p� golvet s� spelar idle animationen.
        }
        else if (OnFloor == false)
        {
            PlayerAniamtion.SetBool("OnFloor", false);

            //Om du inte �r p� golvet s� st�ngs idle animationen av. 
        }

        //NOTE: ExampleAnimation.SetBool("ExampleBool", false eller true); S�tter inte p� eller st�nger av animationerna i sig sj�lv, utan jag har skapat bools i animat�ren som anv�nder sig av boolsen status f�r att v�lja om en viss animation ska spelas.
        //Exempelvist s� kan animat�ren bara spela idle animationen om boolen "OnFloor" �r sann. D�rf�r om vi s�tter att den boolen �r sann n�r vi r�r golvet s� ser animat�ren att boolen �r sann och i sin tur spelar up animationen. 



        if (Input.GetKeyDown(KeyCode.W) && OnFloor == true)
        {
            print("Jump");
            Rb2.AddForce(new Vector3(0, JumpForce, 0));
            OnFloor = false;
            
            //Om du trycker p� W samtidigt som du �r p� golvet s� hoppar du.
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift) && RunCD == false && FearState == false && CanRun == true)
        {
            print("Running Right");
            
            
            Rb2.AddForce(new Vector2(100.0f, Rb2.velocity.y));
            if (Rb2.velocity.x > RightRunSpeed)
            {
                Rb2.velocity = new Vector2(RightRunSpeed, Rb2.velocity.y);
            }

            //H�ller du in Shift och D samtidigt, dvs om du h�ller in shift medan du g�r �t h�ger s� springer du �t h�ger.
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
            
            //H�ller du nere D s� r�r du dig �t h�ger. 
        }
        else 
        {
            MovingRight = false;

            //Om du varken springer eller g�r �t h�ger s� s�tts boolen "MovingRight" till false.
        }



        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift) && RunCD == false && FearState == false && CanRun == true)
        {
            print("Running Left");

            Rb2.AddForce(new Vector2(-100, Rb2.velocity.y));
            if (Rb2.velocity.x < LeftRunSpeed)
            {
                Rb2.velocity = new Vector2(LeftRunSpeed, Rb2.velocity.y);
            }

            //Samma sak som hur man springer �t h�ger, fast nu �t v�nster. H�ller du in A och shift samtidigt s� springer du �t v�nster.
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

                    //H�ller du in A s� r�r du dig �t v�nster.
                }
            }
            

        }
        else
        {
            MovingLeft = false;

            //Om du varken springer eller g�r mot h�ger s� s�tts boolen "MovingLeft" till false.
        }



        if (OnFloor == false && Input.GetKeyDown(KeyCode.Space) && AirDashCD == false && Input.GetKey(KeyCode.D) && FearState == false)
        {
            Rb2.AddForce(new Vector3(DashSpeed, 0, 0));
            AirDashCD = true;
            RunCD = true;
            print("Dashed Right");

            //Om du �r i luften och trycker p� space samtidigt som du h�ller nere D och din AirDash Cooldown ej �r aktiv dvs att den �r falsk s� dashar du �t h�ger.
        }
        if (OnFloor == false && Input.GetKeyDown(KeyCode.Space) && AirDashCD == false && Input.GetKey(KeyCode.A) && FearState == false)
        {
            Rb2.AddForce(new Vector3(-DashSpeed, 0, 0));

            AirDashCD = true;
            RunCD = true;
            print("Dashed Left");

            //Samma sak fast �t v�nster. F�r n�gon anledning fungerar bara h�ger dock.
        }

        if (HasRock == true)
        {
            FindObjectOfType<ShootBehaviour>().ThrowRock();
            
            //Om du har en sten s� aktiveras ThrowRock() i ShootBehaviour scriptet. ThrowRock().
            //ThrowRock() G�r s� att du kan kasta en sten, men f�r att kunna g�ra det m�ste du f�rst ha en sten att kasta dvs din HasRock m�ste vara true.
        }

        if (MovingLeft == false && MovingRight == false)
        {
            Rb2.velocity = new Vector2(0.0f, Rb2.velocity.y);

            //Om du inte r�r dig �t v�nster s� s�tts din velocity i x axeln till 0. Detta f�rhindrar spelaren fr�n att glida p� golvet.
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

        //N�r spelaren �r p�/nuddar marken s� s�tts boolen OnFloor till true samt AriDashCd och RunCD till false. 
        //OnFloor indikerar om och n�r du nuddar marken. Om du faller och sedan nuddar marken s� spelas Landing animationen.
        //Nuddar du marken s� spelas ej Falling animationen.
    }
    public void Rock()
    {
        HasRock = true;

        //N�r funktionen kallas s� s�tts boolen "HasRock" till true. 
        //Denna bool indikerar om karak�tren har tagit upp en sten. Om karakt�ren har tagit upp en sten kan den ej g�ra det igen tills du kastar den f�rsta.
    }
    public void Fear()
    {
        FearState = true;

        //Funktionen s�tter Boolen "FearState" till true. Om du �r i ett FearState l�ge kan du ej Dasha.
    }

    public void Detected()
    {
        FindObjectOfType<TargetMove>().DisableTargetPicking();
        FindObjectOfType<TargetStone>().SwitchTargets();
        FindObjectOfType<BossBehaviour>().RestartGame();
        Destroy(this.gameObject, 5.0f);
        
        //Om funktionen Detected blir kallad s� kallas 3 andra funktioner i olika script. 
        //Dessa funktioner g�r s� att Harvestern siktar in sig p� splearen och n�r spelaren blivit detected s� startar spelet om, dvs du respawnar.
        //5 sekunder efter du blivit hittad s� d�r du.
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FinishGame" && SwitchedScene == 1)
        {
            SceneManager.LoadScene("MainMenu");
            SwitchedScene += 1;
            
            //Om du klarar ut spelet och nuddar ett specifikt game object med tagen "FinishGame" s� byts scenen tillbaks till menyn. 
        }

        if (collision.gameObject.tag == "SneakArea")
        {
            print("BE QUIET");
            FearState = true;
            CanRun = false;
            
            //S� l�nge spelaren �r inne i "SneakArea" omr�det s� s�tts FeatState som sann.
            //Om spelarens FearState �r sann s� kan den ej dasha.
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SneakArea")
        {
            print("u dont have to be quiet :>");
            FearState = false;
            CanRun = true;

            //N�r spelaren g�r ut fr�n SneakArea omr�det s� byts spelarens FearState till false.
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HidingPlace")
        {
            gameObject.tag = "HidingPlayer";

            //Om spelaren �r vid en stor sten eller ett g�mst�lle s� �ndras dess tag till "HidingPlayer".
            //N�r spelaren har tagen "HidingPlayer" s� kan Harvestern inte detecta dig.
        }
        else
        {
            gameObject.tag = "Player";

            //Om spelaren inte �r vid en stor sten eller ett g�mst�lle s� har den sin normala tag, dvs "Player".
        }

        
    }
    
    //Victor's script.
}
