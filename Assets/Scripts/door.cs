using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    private bool playerDetected;
    public Transform doorPos;
    public float widht;
    public float height;
    public LayerMask whatIsPlayer;
    
    [SerializeField]
    private string sceneName;

    SceenSwitch sceneSwitch;

    private void Start()
    {
        sceneSwitch = FindObjectOfType<SceenSwitch>();
    }

    private void Update()
    {
        playerDetected = Physics2D.OverlapBox(doorPos.position, new Vector2(widht, height), 0, whatIsPlayer);

        if (playerDetected == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                sceneSwitch.SwitchScene(sceneName);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(doorPos.position, new Vector3(widht, height, 1));
    }

}

