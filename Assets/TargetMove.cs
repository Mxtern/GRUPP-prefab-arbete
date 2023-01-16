using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove : MonoBehaviour
{
    [SerializeField]
    public float TimeUntilSwitch = 5.0f;
    public float TimeLeft;
    public Transform TargetStone1 = null;
    public Transform TargetStone2 = null;
    public Transform TargetStone3 = null;
    public Transform TargetStone4 = null;

    public int RandomStone;
    public int PreviousStone;


    // Start is called before the first frame update
    void Start()
    {
        TimeLeft += TimeUntilSwitch;
        PickTarget();
    }

    // Update is called once per frame
    void Update()
    {
        TimeLeft -= (1 * Time.deltaTime);
        if (TimeLeft <= 0.0f)
        {
            PickTarget();
            TimeLeft += TimeUntilSwitch;
        }
    }
    public void PickTarget()
    {
        RandomStone = Random.Range(0, 4);
        if (RandomStone == PreviousStone)
        {
            RandomStone = Random.Range(0, 4);
        }
        PreviousStone = RandomStone;

        if (RandomStone == 0)
        {
            transform.position = TargetStone1.position;
        }
        if (RandomStone == 1)
        {
            transform.position = TargetStone2.position;
        }
        if (RandomStone == 2)
        {
            transform.position = TargetStone3.position;
        }
        if (RandomStone == 3)
        {
            transform.position = TargetStone4.position;
        }
    }
}
