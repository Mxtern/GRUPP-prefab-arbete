using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCamShake : MonoBehaviour
{
    Vector3 OriginalPosition;
    public int RandomX;
    public int RandomY;
    public float OrginX;
    public float OrginY;
    public float OrginZ;

    
    
    // Start is called before the first frame update
    void Start()
    {
        OriginalPosition = transform.localPosition;
        OrginX = OriginalPosition.x;
        OrginY = OriginalPosition.y;
        OrginZ = OriginalPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScreenShaking()
    {
        print("SCREEN IS SHAKING");
        RandomX = Random.Range(-1, 2);
        if (RandomX == 0)
        {
            RandomX = Random.Range(-1, 2);
        }

        else
        {
            transform.localPosition += new Vector3(RandomX * 0.25f, RandomY * 0.25f);
        }

        RandomY = Random.Range(-1, 2);
        if (RandomY == 0)
        {
            RandomY = Random.Range(-1, 2);
        }

        else
        {
            transform.localPosition += new Vector3(RandomX * 0.25f, RandomY * 0.25f);
        }


    }

    public void ScreenReset()
    {
        transform.localPosition = new Vector3(OrginX, OrginY, OrginZ);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BossCamBorder")
        {
            print("Weewoo");
            ScreenReset();
        }
    }
}
