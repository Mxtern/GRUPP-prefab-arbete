using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStand : MonoBehaviour //Scriptet gör så att Bossens gameObject rör sig mot ett annat gameObject i en smidig rörelse.
{
    public Transform StandLerp = null; //Hittar positionen av objektet som bossen ska röra sig mot under dess start animation.

    public float T;

    [SerializeField]
    public float Speed; //Hastigheten som bossen rör sig mot lerp objektet. 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 a = transform.position; //Sätter Vector3 "a" som det här objektet (bossens) position.
        Vector3 b = StandLerp.position; //Sätter Vector3 "b" som lerp (objektet som bossen ska röra sig mot) objektets position. 
        transform.position = Vector3.MoveTowards(a, Vector3.Lerp(a, b, T), Speed); //Flyttar boss spriten upp i en jämn hastighet medans den visuellt ställer sig up. Detta gör att bossen ser mer realistisk och mindre stel ut när den ställer sig up.
    }

    //Victor's script.
}
