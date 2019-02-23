using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float speed;
    private bool wallFreeN = true;
    private bool wallFreeS = true;
    private bool wallFreeW = true;
    private bool wallFreeE = true;
    public GameObject bullet;
    public int health;
    public float fireRate;
    private float nextFire;
    // Use this for initialization
    void Start()
    {

    }


    void FixedUpdate()
    {
        playerMovement();
        playerShooting();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.Contains("wall"))
        {
            playerWall(other);
        }

    }

    private void playerShooting()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && Time.time > nextFire)
        {
            GameObject bullet = Instantiate(this.bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
            bullet.GetComponent<BulletScript>().way = BulletScript.direction.west;
        }
        if (Input.GetKey(KeyCode.RightArrow) && Time.time > nextFire)
        {
            GameObject bullet = Instantiate(this.bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
            bullet.GetComponent<BulletScript>().way = BulletScript.direction.east;

        }
        if (Input.GetKey(KeyCode.UpArrow) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject bullet = Instantiate(this.bullet, transform.position, Quaternion.identity);
            bullet.GetComponent<BulletScript>().way = BulletScript.direction.north;
        }
        if (Input.GetKey(KeyCode.DownArrow) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject bullet = Instantiate(this.bullet, transform.position, Quaternion.identity);
            bullet.GetComponent<BulletScript>().way = BulletScript.direction.south;
            Instantiate(bullet);
        }

    }

    private void playerWall(Collider2D other)
    {
        if (other.name.Contains("wall west"))
        {
            wallFreeW = false;
            transform.position -= Vector3.left * speed * Time.deltaTime;
        }
        if (other.name.Contains("wall east"))
        {
            wallFreeE = false;
            transform.position -= Vector3.right * speed * Time.deltaTime;
        }
        if (other.name.Contains("wall north"))
        {
            wallFreeN = false;
            transform.position -= Vector3.up * speed * Time.deltaTime;
        }
        if (other.name.Contains("wall south"))
        {
            wallFreeS = false;
            transform.position -= Vector3.down * speed * Time.deltaTime;
        }
    }



    private void playerMovement()
    {


        if (Input.GetKey(KeyCode.A))
        {
            if (wallFreeW)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (wallFreeE)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (wallFreeN)
            {
                transform.position += Vector3.up * speed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (wallFreeS)
            {
                transform.position += Vector3.down * speed * Time.deltaTime;
            }
        }
        wallFreeN = true;
        wallFreeS = true;
        wallFreeW = true;
        wallFreeE = true;
    }


}
