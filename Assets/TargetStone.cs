using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetStone : MonoBehaviour
{
    public Transform TargetTarget = null;

    public float T;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 a = transform.position;
        Vector3 b = TargetTarget.position;
        transform.position = Vector3.MoveTowards(a, Vector3.Lerp(a, b, T), Speed);

    }
}
