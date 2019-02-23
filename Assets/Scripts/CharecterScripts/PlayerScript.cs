using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float speed;
    private bool wallFreeU = true;
    private bool wallFreeD = true;
    private bool wallFreeL = true;
    private bool wallFreeR = true;

    // Use this for initialization
    void Start()
    {

    }


    void FixedUpdate()
    {
        playerMovement();
    }





    private void playerMovement() {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (wallFreeL)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            else
            {
                //wallFree = true;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (wallFreeR)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            else
            {
                //wallFree = true;
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (wallFreeU)
            {
                transform.position += Vector3.up * speed * Time.deltaTime;
            }
            else
            {
                //wallFree = true;
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (wallFreeD)
            {
                transform.position += Vector3.down * speed * Time.deltaTime;
            }
            else
            {

            }
        }
        wallFreeU = true;
        wallFreeD = true;
        wallFreeL = true;
        wallFreeR = true;

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        wallStop();


    }

    private void wallStop(){

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            wallFreeL = false;
            transform.position -= Vector3.left * speed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            wallFreeR = false;
            transform.position -= Vector3.right * speed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            wallFreeU = false;
            transform.position -= Vector3.up * speed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            wallFreeD = false;
            transform.position -= Vector3.down * speed * Time.deltaTime;

        }
    }

    
}
