using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TargetStone : MonoBehaviour
{
    public Transform TargetTarget = null;
    public Transform TargetPlayer = null;
    public Transform TargetDistraction = null;

    public bool TargetingTarget = true;
    public bool TargetingPlayer = false;
    public bool TargetingDistraction = false;


    public float T;

    [SerializeField]
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

            //Gör så att objektet som Harvestern's siktare pekar mot flyttar sig i en jämn hastighet mot stenen som den ska sikta sig in på. 
            //Detta gör harvesterns targeting visuals mer smooth.
        }
        else if (TargetingDistraction == true)
        {
            Vector3 c = transform.position;
            Vector3 d = TargetDistraction.position;
            transform.position = Vector3.MoveTowards(c, Vector3.Lerp(c, d, T), Speed);

            //Gör så att siktar-rotation objektet flyttar sig i en jämn hastighet mot stenen den detectat.
        }
        if (TargetingPlayer == true)
        {
            Vector3 e = transform.position;
            Vector3 f = TargetPlayer.position;
            transform.position = Vector3.MoveTowards(e, Vector3.Lerp(e, f, T), Speed);

            //Gör så att siktar-rotation objektet flyttar sig i en jämn hastighet mot spelaren om den blivit detectad.
        }
        
    }
    public void SwitchTargets()
    {
        TargetingTarget = false;
        TargetingPlayer = true;
        
        //Byter targets från de stora stenarna till spelaren.
    }
    public void HarvesterDistracted(Transform rock)
    {
        TargetDistraction = rock;
        TargetingTarget = false;
        TargetingDistraction = true;

        //Byter targets från de stora stenarna till stenen man kastat.
    }
    public void StoneToTarget()
    {
        TargetingDistraction = false;
        TargetingTarget = true;

        //Byter targets från stenen man kastat till de stora stenarna.
    }

    //Victor's script.
}
