using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSurvivor : MonoBehaviour
{
    public SpriteRenderer PlayerSprite;

    // Start is called before the first frame update
    void Start()
    {
        PlayerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void FlipPlayerLeft()
    {
        PlayerSprite.flipX = true;

        //Flippar spelar spriten s� att den kollar �t v�nster.
    }
    public void FlipPlayerRight()
    {
        PlayerSprite.flipX = false;

        //Flippar spelar spriten s� att den kollar �t h�ger.
    }

    //Victor's script.
}
