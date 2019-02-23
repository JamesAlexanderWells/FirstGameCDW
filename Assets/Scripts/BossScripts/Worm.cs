using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Worm : MonoBehaviour
{
    public Transform target;
    public float speed;
    private bool moveU = false;
    private bool moveD = false;
    private bool moveL = false;
    private bool moveR = false;
    public float r;
    private float xDistance;
    private float yDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        xDistance = target.position.x - transform.position.x;
        yDistance = target.position.y - transform.position.y;
        if (moveU)
        {
            transform.position -= Vector3.down * speed * Time.deltaTime;
        }
        if (moveD)
        {
            transform.position -= Vector3.up * speed * Time.deltaTime;
        }
        if (moveL)
        {
            transform.position -= Vector3.left * speed * Time.deltaTime;
        }
        if (moveR)
        {
            transform.position -= Vector3.right * speed * Time.deltaTime;
        }
        if (r == 0)
        {
            moveU = true;
            moveD = false;
            moveL = false;
            moveR = false;
        }
        if (r == 1)
        {
            moveU = false;
            moveD = true;
            moveL = false;
            moveR = false;
        }
        if (r == 2)
        {
            moveU = false;
            moveD = false;
            moveL = true;
            moveR = false;
        }
        if (r == 3)
        {
            moveU = false;
            moveD = false;
            moveL = false;
            moveR = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "Scenery")
        {
            if (xDistance > -xDistance)
            {
                if(xDistance > yDistance)
                {
                    if (xDistance > -yDistance)
                    {
                        if (!moveL)
                            r = 2;
                        else
                            r = 1;
                    }
                }
            }
            else if (-xDistance > yDistance)
            {
                if(-xDistance > - yDistance)
                {
                    if (!moveR)
                        r = 3;
                    else
                        r = 0;
                }
            }
            else if (yDistance > -yDistance)
            {
                r = 0;
            }
            else
            {
                r = 1;
            }
            
        }
    }
}