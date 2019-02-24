using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    public float speed;

    public enum direction
    {
        north,
        south,
        east,
        west,
        stop
    };

    public direction way = direction.stop;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement();

    }


    void movement()
    {
        switch (way)
        {
            case direction.north:
                this.transform.position += Vector3.up * speed * Time.deltaTime;
                break;
            case direction.south:
                transform.position += Vector3.down * speed * Time.deltaTime;
                break;
            case direction.east:
                this.transform.position += Vector3.right * speed * Time.deltaTime;
                break;
            case direction.west:
                this.transform.position += Vector3.left * speed * Time.deltaTime;
                break;
            default:
                break;
        }

    }

    void OnTriggerEnter2D(Collider2D thing)
    {
        if (thing.name.Contains("Wall"))
        {
            Destroy(this.gameObject);
        }

    }
}
