using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove : MonoBehaviour
{
    [SerializeField]
    public float TimeUntilSwitch = 4.2f;
    public float TimeLeft;
    public Transform TargetStone1 = null;
    public Transform TargetStone2 = null;
    public Transform TargetStone3 = null;
    public Transform TargetStone4 = null;
    public Transform TargetStone5 = null;
    public Transform TargetStone6 = null;
    public Transform TargetStone7 = null;
    public Transform TargetStone8 = null;
    public Transform PlayerTarget = null;

    public int RandomStone;
    public int PreviousStone;

    public bool TargetLow;
    public bool TargetUp;
    public bool Targeting = (true);
    public bool DistractionActive = (false);

    // Start is called before the first frame update
    void Start()
    {
        TimeLeft += TimeUntilSwitch;
        TargetLow = true;
        TargetUp = false;
        PickLowerTarget();
    }

    // Update is called once per frame
    void Update()
    {
        TimeLeft -= (1 * Time.deltaTime);
        if (TimeLeft <= 0.0f && Targeting == true && TargetLow)
        {
            PickLowerTarget();
            TimeLeft += TimeUntilSwitch;
        }
        else if (TimeLeft <= 0.0f && DistractionActive == true) 
        {
            FindObjectOfType<TargetStone>().StoneToTarget();
            DistractionActive = false;
            Targeting = true;

        }
        if (TimeLeft <= 0.0f && Targeting == true && TargetUp)
        {
            PickUpperTarget();
            TimeLeft += TimeUntilSwitch;
        }
        else if (TimeLeft <= 0.0f && DistractionActive == true)
        {
            FindObjectOfType<TargetStone>().StoneToTarget();
            DistractionActive = false;
            Targeting = true;

        }
    }
    public void DisableTargetPicking()
    {
        Targeting = false;
        
    }
    public void Distracted()
    {
        Targeting = false;
        DistractionActive = true;
        TimeLeft = 4.2f;

    }
    public void PickLowerTarget()
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
    public void PickUpperTarget()
    {
        RandomStone = Random.Range(0, 4);
        if (RandomStone == PreviousStone)
        {
            RandomStone = Random.Range(0, 4);
        }
        PreviousStone = RandomStone;

        if (RandomStone == 0)
        {
            transform.position = TargetStone5.position;
        }
        if (RandomStone == 1)
        {
            transform.position = TargetStone6.position;
        }
        if (RandomStone == 2)
        {
            transform.position = TargetStone7.position;
        }
        if (RandomStone == 3)
        {
            transform.position = TargetStone8.position;
        }

    }
}
