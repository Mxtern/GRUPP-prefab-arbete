using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehaviour : MonoBehaviour
{
    public Camera PlayerCam;

    public GameObject RockPrefab;
    public GameObject Player;
    public bool ThrewRock;
    Camera[] cameras;

    private Vector3 MousePos;

    
    // Start is called before the first frame update
    void Start()
    {
        cameras = FindObjectsOfType<Camera>();
        /*PlayerCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();*/
    }
    public void SetCamera()
    {
        Vector3 temp = Input.mousePosition;
        temp.z = -10;
        foreach (Camera cam in cameras)
        {
            if (cam.gameObject.activeSelf == true)
            {
                print(cam.name);
                MousePos = cam.ScreenToWorldPoint(temp);
                return;
            }

            //Kollar vilken kamera som �r aktiverad. 
        }
        print("Cant find camera");
        cameras = FindObjectsOfType<Camera>();
        SetCamera();

        //Letar efter kameror. 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetCamera();
       

        Vector3 AimRotation = MousePos - transform.position; //riktningen fr�n mus till spelare
        float RotationZ = Mathf.Atan2(AimRotation.y, AimRotation.x) * Mathf.Rad2Deg; //rotation i radiner omvandlat till grader
        transform.rotation = Quaternion.Euler(0, 0, RotationZ); //shooter aimern f�r samma rotation som r�knats ut.

        

        if (ThrewRock == true)
        {
            CreateRock(RotationZ);
            ThrewRock = false;

            //Om man kastar en sten skapas en sten i en rotation som pekar mot musen.
        }

    }
    public void ThrowRock()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ThrewRock = true;
            FindObjectOfType<PlayerMovement>().HasRock = false;

            //Kastar du en sten s� kan du inte kasta en till d� du inte l�ngre har den. Du kan kasta en till om du tar upp en annan sten.
        }
        
    }
    void CreateRock(float RotationZ)
    {
        GameObject Rock = Instantiate(RockPrefab) as GameObject;
        Rock.transform.position = Player.transform.position; //S�tter stenens position detsamma som spelarens.
        Rock.transform.rotation = Quaternion.Euler(0.0f, 0.0f, RotationZ); //Ger stenen samma rotation som tidigare r�knats ut.

        
    }

    //Victor's script.
}
