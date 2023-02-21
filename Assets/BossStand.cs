using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStand : MonoBehaviour //Scriptet g�r s� att Bossens gameObject r�r sig mot ett annat gameObject i en smidig r�relse.
{
    public Transform StandLerp = null; //Hittar positionen av objektet som bossen ska r�ra sig mot under dess start animation.

    public float T;

    [SerializeField]
    public float Speed; //Hastigheten som bossen r�r sig mot lerp objektet. 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 a = transform.position; //S�tter Vector3 "a" som det h�r objektet (bossens) position.
        Vector3 b = StandLerp.position; //S�tter Vector3 "b" som lerp (objektet som bossen ska r�ra sig mot) objektets position. 
        transform.position = Vector3.MoveTowards(a, Vector3.Lerp(a, b, T), Speed); //Flyttar boss spriten upp i en j�mn hastighet medans den visuellt st�ller sig up. Detta g�r att bossen ser mer realistisk och mindre stel ut n�r den st�ller sig up.
    }

    //Victor's script.
}
