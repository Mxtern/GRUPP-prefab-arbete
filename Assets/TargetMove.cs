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

            //TimeLeft är lika med 4.2 sekunder som minskar med verklig tid hela tiden. Om 4.2 sekunder har gått och om bossen siktar på den lägre delen av boss arenan så byter bossen sitt target i den undre arenan och TimeLeft får tillbaka sin ursprungliga tid.
        }
        else if (TimeLeft <= 0.0f && DistractionActive == true) 
        {
            FindObjectOfType<TargetStone>().StoneToTarget();
            DistractionActive = false;
            Targeting = true;

            //Om tiden har runnit ut och bossen är distraherad så siktar bossen in sig på stenen.
        }
        if (TimeLeft <= 0.0f && Targeting == true && TargetUp)
        {
            PickUpperTarget();
            TimeLeft += TimeUntilSwitch;

            //Om TimeLeft tiden rinner ut och bossen siktar in sig på den övre arenan så väljer den ett nytt target i den övre arenan och TimeLeft tiden resetas till 4.2.
        }
        else if (TimeLeft <= 0.0f && DistractionActive == true)
        {
            FindObjectOfType<TargetStone>().StoneToTarget();
            DistractionActive = false;
            Targeting = true;

            //Om tiden runnit ut och bossen är distraherad så siktar bossen in sig på stenen.
        }
    }
    public void DisableTargetPicking()
    {
        Targeting = false;
        
        //Stänger av targeting.
    }
    public void Distracted()
    {
        Targeting = false;
        DistractionActive = true;
        TimeLeft = 4.2f;

        //Stänger av targeting och sätter DistractionActive till true. TimeLeft sätts tillbaka till 4.2. Detta gör så att bossen blir distraherad i 4.2 sekunder.
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

        //Väljer en random sten att sikta in sig på. Om som väljs är detsamma som den förra så väljs stenen om.
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

        //Samma sak som PickLowerTarget fast med de övre targetserna.
    }

    //Victor's script.
}
