using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderGravity : MonoBehaviour
{
    public Transform LadderLerp = null;
    

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(LadderLerp);
        transform.right = LadderLerp.position - transform.position;
    }
}
