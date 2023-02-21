using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RockThrow : MonoBehaviour
{
    public GameObject Player;
    public GameObject RockPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnRock()
    {
        GameObject Rock = Instantiate(RockPrefab, transform.position, transform.rotation) as GameObject;
        Rock.transform.position = Player.transform.position;
    }
}
