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

        }
        print("Cant find camera");
        cameras = FindObjectsOfType<Camera>();
        SetCamera();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetCamera();
       

        Vector3 AimRotation = MousePos - transform.position;
        float RotationZ = Mathf.Atan2(AimRotation.y, AimRotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, RotationZ);

        if (ThrewRock == true)
        {
            CreateRock(RotationZ);
            ThrewRock = false;

        }

    }
    public void ThrowRock()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ThrewRock = true;
            FindObjectOfType<PlayerMovement>().HasRock = false;
        }
        
    }
    void CreateRock(float RotationZ)
    {
        GameObject Rock = Instantiate(RockPrefab) as GameObject;
        Rock.transform.position = Player.transform.position;
        Rock.transform.rotation = Quaternion.Euler(0.0f, 0.0f, RotationZ);
    }

}
