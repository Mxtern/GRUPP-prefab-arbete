using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetStone : MonoBehaviour
{
    public Transform TargetTarget = null;
    public Transform TargetPlayer = null;

    public bool TargetingTarget = true;
    public bool TargetingPlayer = false;

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
        else if (TargetingPlayer == true)
        {
            Vector3 a = transform.position;
            Vector3 b = TargetPlayer.position;
            transform.position = Vector3.MoveTowards(a, Vector3.Lerp(a, b, T), Speed);
        }

    }
    public void SwitchTargets()
    {
        TargetingTarget = false;
        TargetingPlayer = true;
    }
}
