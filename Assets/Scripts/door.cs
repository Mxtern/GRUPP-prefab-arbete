using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    // bool f�r om player �r detectad eller inte
    private bool playerDetected;
    //d�rrens position
    public Transform doorPos;
    //d�rrens position
    public float widht;
    public float height;
    //Vilket layer d�rren ska detecta player i 
    public LayerMask whatIsPlayer;
    
    [SerializeField]
    private string sceneName;// vilken scene spelet ska switcha till

    SceenSwitch sceneSwitch;

    private void Start()
    {
        sceneSwitch = FindObjectOfType<SceenSwitch>(); //s� du kan switcha scenes
    }

    private void Update()
    {
        playerDetected = Physics2D.OverlapBox(doorPos.position, new Vector2(widht, height), 0, whatIsPlayer); //detectar om player �r framf�r gizmon/d�rren

        if (playerDetected == true) //om du trycker E s� �ndrar spelet scene/�pnar d�rren
        {
            if (Input.GetKey(KeyCode.E))
            {
                sceneSwitch.SwitchScene(sceneName);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue; //F�rgen p� gizmosens outline
        Gizmos.DrawWireCube(doorPos.position, new Vector3(widht, height, 1));// positionen p� d�rren
    }
    
}

