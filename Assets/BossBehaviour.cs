using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    

    public Transform FollowStones = null;
    public Transform FollowPlayer = null;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(FollowStones);
        transform.right = FollowStones.position - transform.position;
    }
    
    public void TargetPlayer()
    {
        FollowStones = FollowPlayer;
    }
}
