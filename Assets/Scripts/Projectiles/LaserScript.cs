using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{

    public GameObject player;
    public GameObject bulletSpriteList;
    int reversal = 1;
    private float initializationTime;
    CircleCollider2D cC2D;
    SpriteRenderer sRend;
    public enum direction
    {
        north,
        south,
        east,
        west,
        stop
    };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
