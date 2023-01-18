using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetStone : MonoBehaviour
{
    public Transform TargetTarget = null;
    public Transform TargetPlayer = null;
    public Transform TargetDistraction = null;

    public bool TargetingTarget = true;
    public bool TargetingPlayer = false;
    public bool TargetingDistraction = false;

    
    public float T;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

        if (TargetingTarget == true)
        {
            Vector3 a = transform.position;
            Vector3 b = TargetTarget.position;
            transform.position = Vector3.MoveTowards(a, Vector3.Lerp(a, b, T), Speed);
        }
        if (TargetingDistraction == true)
        {
            Vector3 c = transform.position;
            Vector3 d = TargetDistraction.position;
            transform.position = Vector3.MoveTowards(c, Vector3.Lerp(c, d, T), Speed);

        }
        if (TargetingPlayer == true)
        {
            Vector3 e = transform.position;
            Vector3 f = TargetPlayer.position;
            transform.position = Vector3.MoveTowards(e, Vector3.Lerp(e, f, T), Speed);
        }
        
    }
    public void SwitchTargets()
    {
        TargetingTarget = false;
        TargetingPlayer = true;
    }
    public void HarvesterDistracted()
    {
        TargetingTarget = false;
        TargetingDistraction = true;
    }
    public void StoneToTarget()
    {
        TargetingDistraction = false;
        TargetingTarget = true;
    }
}
