using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStart : MonoBehaviour
{
    public GameObject Boss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("weewoo");
            Boss.SetActive(true);
            FindObjectOfType<EnemyBehaviour>().WaitAndStart();
            Destroy(this.gameObject);
        }
    }
}
