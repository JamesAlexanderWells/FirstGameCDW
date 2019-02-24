using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.Scripts.Rooms;

public class Flower : MonoBehaviour
{
    public GameObject tentacle;
    public Transform target;
    private float range;
    public float speed;
    private Animator anim;
    private float currentY;
    private float previousY;
    private float tentacleHTimer;
    private float tentacleWTimer;
    private bool tentacleHSpawn;
    private bool tentacleWSpawn;
    private float tentacleH;
    private float tentacleW;
    private float rH;
    private float rW;
    private float Height;
    private float Width;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentY = this.transform.position.y;
        previousY = 0;
        tentacleHTimer = Time.time;
        tentacleWTimer = Time.time;

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 theScale = transform.localScale;
        range = Vector2.Distance(transform.position, target.position);
        if (this.transform.position.x > target.transform.position.x)
        {
            theScale.x = 1;
            transform.localScale = theScale;
        }
        else
        {
            theScale.x = -1;
            transform.localScale = theScale;
        }
        if (range < 500)
        {

            transform.position = Vector2.MoveTowards(transform.position, target.position, -1*speed * Time.deltaTime);
        }
        GoingUp();
        if (tentacleHSpawn)
        {
            tentacleHSpawn = false;
            rH = GetRandomNumber(0, Height);

        }
        if (tentacleWSpawn)
        {
            tentacleWSpawn = false;
        }
        if (Time.time - tentacleHTimer > 1)
        {
            tentacleHTimer = Time.time;
            tentacleHSpawn = true;
        }
        if (Time.time - tentacleWTimer > 2)
        {
            tentacleWTimer = Time.time;
            tentacleWSpawn = true;
        }
    }
    bool GoingUp()
    {
        previousY = currentY;
        currentY = this.transform.position.y;
        if(currentY > previousY)
        {
            anim.SetBool("isBackwards", true);
            return true;           
        }
        else
        {
            anim.SetBool("isBackwards", false);
            return false;           
        }
    }
    public float GetRandomNumber(float minimum, float maximum)
    {
        System.Random random = new System.Random();
        return random.Next() * (maximum - minimum) + minimum;
    }
}
