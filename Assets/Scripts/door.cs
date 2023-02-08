using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    // bool för om player är detectad eller inte
    private bool playerDetected;
    //dörrens position
    public Transform doorPos;
    //dörrens position
    public float widht;
    public float height;
    //Vilket layer dörren ska detecta player i 
    public LayerMask whatIsPlayer;
    
    [SerializeField]
    private string sceneName;// vilken scene spelet ska switcha till

    SceenSwitch sceneSwitch;

    private void Start()
    {
        sceneSwitch = FindObjectOfType<SceenSwitch>(); //så du kan switcha scenes
    }

    private void Update()
    {
        playerDetected = Physics2D.OverlapBox(doorPos.position, new Vector2(widht, height), 0, whatIsPlayer); //detectar om player är framför gizmon/dörren

        if (playerDetected == true) //om du trycker E så ändrar spelet scene/öpnar dörren
        {
            if (Input.GetKey(KeyCode.E))
            {
                sceneSwitch.SwitchScene(sceneName);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue; //Färgen på gizmosens outline
        Gizmos.DrawWireCube(doorPos.position, new Vector3(widht, height, 1));// positionen på dörren
    }
    
}

