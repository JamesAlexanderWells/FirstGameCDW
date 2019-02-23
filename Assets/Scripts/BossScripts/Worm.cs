using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Worm : MonoBehaviour
{
    public Transform target;
    public float speed;
    public bool moveU = false;
    public bool moveD = false;
    public bool moveL = false;
    public bool moveR = false;
    public float r;
    private float xDistance;
    private float yDistance;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        xDistance = target.position.x - transform.position.x;
        yDistance = target.position.y - transform.position.y;
        Vector3 theScale = transform.localScale;
        Debug.Log(theScale.x);
        if (moveU)
        {
            transform.position -= Vector3.down * speed * Time.deltaTime;
            anim.SetBool("isRight", false);
            anim.SetBool("isLeft", false);
            anim.SetBool("isUp", true);
            anim.SetBool("isDown", false);
            theScale.x = 1;
            transform.localScale = theScale;
        }
        if (moveD)
        {
            transform.position -= Vector3.up * speed * Time.deltaTime;
            anim.SetBool("isRight", false);
            anim.SetBool("isLeft", false);
            anim.SetBool("isUp", false);
            anim.SetBool("isDown", true);
            theScale.x = 1;
            transform.localScale = theScale;
        }
        if (moveR)
        {
            transform.position -= Vector3.left * speed * Time.deltaTime;
            anim.SetBool("isRight", true);
            anim.SetBool("isLeft", false);
            anim.SetBool("isUp", false);
            anim.SetBool("isDown", false);
            theScale.x = 1;
            transform.localScale = theScale;
        }
        if (moveL)
        {
            theScale.x = -1;
            transform.localScale = theScale;
            transform.position -= Vector3.right * speed * Time.deltaTime;
            anim.SetBool("isRight", false);
            anim.SetBool("isLeft", true);
            anim.SetBool("isUp", false);
            anim.SetBool("isDown", false);
        }
        if (r == 0)
        {
            moveU = true;
            moveD = false;
            moveR = false;
            moveL = false;
        }
        if (r == 1)
        {
            moveU = false;
            moveD = true;
            moveR = false;
            moveL = false;
        }
        if (r == 2)
        {
            moveU = false;
            moveD = false;
            moveR = true;
            moveL = false;
        }
        if (r == 3)
        {
            moveU = false;
            moveD = false;
            moveR = false;
            moveL = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Scenery")
        {
            if (xDistance > -xDistance)
            {
                if (xDistance > yDistance)
                {
                    if (xDistance > -yDistance)
                    {
                        if (!moveR)
                            r = 2;
                        else
                            r = 1;
                    }
                }
            }
            else if (-xDistance > yDistance)
            {
                if (-xDistance > -yDistance)
                {
                    if (!moveL)
                        r = 3;
                    else
                        r = 0;
                }
            }
            if (yDistance > -yDistance)
            {
                if (yDistance > xDistance)
                {
                    if (yDistance > -xDistance)
                    {
                        if (!moveU)
                            r = 0;
                        else
                            r = 2;
                    }
                }
            }
            else if (-yDistance > xDistance)
            {
                if (-yDistance > -xDistance)
                {
                    if (!moveD)
                        r = 1;
                    else
                        r = 3;
                }
            }
        }
    }
}