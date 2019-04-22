using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
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

    public direction way = direction.stop;


    public SpriteRenderer ownSprite;

    void Start()
    {
        if (this.name.Contains("Clone"))
        {
            initializationTime = Time.timeSinceLevelLoad;
            addComponents();
            changeBulletApperance();
        }
    }

    void FixedUpdate()
    {
        if (this.name.Contains("Clone"))
        {
            movement();
            timeOut();
        }
    }


    private void addComponents()
    {
        cC2D = gameObject.AddComponent(typeof(CircleCollider2D)) as CircleCollider2D;
        sRend = gameObject.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;

        cC2D.isTrigger = true;
        cC2D.radius = 1.436925f;

        sRend.sprite = bulletSpriteList.GetComponent<BulletSpriteList>().baisicBullet;
        sRend.sortingOrder = 2;
    }

    private void changeBulletApperance()
    {
        if (player.GetComponent<PlayerScript>().pickUpList.Any(f => f.pickUpName == PickUpScript.nameType.laser))
        {
            sRend.sprite = bulletSpriteList.GetComponent<BulletSpriteList>().laserBullet;
        }
        else if (player.GetComponent<PlayerScript>().pickUpList.Any(f => f.pickUpName == PickUpScript.nameType.fireBall))
        {
            sRend.sprite = bulletSpriteList.GetComponent<BulletSpriteList>().fireBallBullet;
        }
        else if (player.GetComponent<PlayerScript>().pickUpList.Any(f => f.pickUpName == PickUpScript.nameType.boomerang))
        {
            sRend.sprite = bulletSpriteList.GetComponent<BulletSpriteList>().boomerangBullet;
        }
        else if (player.GetComponent<PlayerScript>().pickUpList.Any(f => f.pickUpName == PickUpScript.nameType.dimensionPhase))
        {
            sRend.sprite = bulletSpriteList.GetComponent<BulletSpriteList>().spectralBullet;
        }
        else if (player.GetComponent<PlayerScript>().pickUpList.Any(f => f.pickUpName == PickUpScript.nameType.squashBall))
        {
            sRend.sprite = bulletSpriteList.GetComponent<BulletSpriteList>().bouncyBullet;
        }
    }

    void timeOut()
    {
        if (3 <= Time.timeSinceLevelLoad - initializationTime)
        {
            Destroy(this.gameObject);
        }
    }

    void movement()
    {

        if (1.5 <= Time.timeSinceLevelLoad - initializationTime && player.GetComponent<PlayerScript>().pickUpList.Any(f => f.pickUpName == PickUpScript.nameType.boomerang))
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            switch (way)
            {
                case direction.north:
                    this.transform.position += (Vector3.up * speed * Time.deltaTime) * reversal;
                    break;
                case direction.south:
                    transform.position += (Vector3.down * speed * Time.deltaTime) * reversal;
                    break;
                case direction.east:
                    this.transform.position += (Vector3.right * speed * Time.deltaTime) * reversal;
                    break;
                case direction.west:
                    this.transform.position += (Vector3.left * speed * Time.deltaTime) * reversal;
                    break;
                default:
                    break;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D thing)
    {
        if (thing.name.Contains("Wall") || thing.name.Contains("Rock") || thing.tag == "Boss")
        {
            if (player.GetComponent<PlayerScript>().pickUpList.Any(f => f.pickUpName == PickUpScript.nameType.squashBall))
            {
                reversal *= -1;
            }
            else if (player.GetComponent<PlayerScript>().pickUpList.Any(f => f.pickUpName == PickUpScript.nameType.dimensionPhase))
            {

            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        if (thing.name.Contains("player") && reversal == -1 && player.GetComponent<PlayerScript>().pickUpList.Any(f => f.pickUpName == PickUpScript.nameType.boomerang))
        {
            Destroy(this.gameObject);
        }

    }
}