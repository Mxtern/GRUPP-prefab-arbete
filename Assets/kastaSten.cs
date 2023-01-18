using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kastaSten : MonoBehaviour
{

    public GameObject sten;
    public Transform firePoint;
    public float bulletSpeed = 25;

    Vector2 lookDirection;
    float lookAngle;

    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);

        if (Input.GetMouseButtonDown(0))
        {
            GameObject stenClone = Instantiate(sten);
            stenClone.transform.position = firePoint.position;
            stenClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

            stenClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;
        }
    }





}
