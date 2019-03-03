using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    public float speed;
    public GameObject player;
    public GameObject bulletSpriteList;
    int reversal = 1;
    private float initializationTime;
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
        initializationTime = Time.timeSinceLevelLoad;
        changeBulletApperance();
    }

    private void changeBulletApperance()
    {
        if (player.GetComponent<PlayerScript>().pickUpList.Any(f => f.pickUpName == PickUpScript.nameType.fireBall))
        {
            this.ownSprite.sprite = bulletSpriteList.GetComponent<BulletSpriteList>().fireBallBullet;
        }
        else if (player.GetComponent<PlayerScript>().pickUpList.Any(f => f.pickUpName == PickUpScript.nameType.boomerang)) {
            this.ownSprite.sprite = bulletSpriteList.GetComponent<BulletSpriteList>().boomerangBullet;
        }
        else if (player.GetComponent<PlayerScript>().pickUpList.Any(f => f.pickUpName == PickUpScript.nameType.dimensionPhase)) {
            this.ownSprite.sprite = bulletSpriteList.GetComponent<BulletSpriteList>().spectralBullet;
        }
        else if (player.GetComponent<PlayerScript>().pickUpList.Any(f => f.pickUpName == PickUpScript.nameType.squashBall))
        {
            this.ownSprite.sprite = bulletSpriteList.GetComponent<BulletSpriteList>().bouncyBullet;
        }




    }


    void FixedUpdate()
    {
        movement();
        timeOut();
    }

    void timeOut() {
        if ( 3 <= Time.timeSinceLevelLoad - initializationTime && this.name.Contains("Clone")) {
            Destroy(this.gameObject);
        }
    }

    void movement()
    {

        if (1.5 <= Time.timeSinceLevelLoad - initializationTime && player.GetComponent<PlayerScript>().pickUpList.Any(f => f.pickUpName == PickUpScript.nameType.boomerang) && this.name.Contains("Clone"))
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
        if (thing.name.Contains("Wall") || thing.name.Contains("Rock"))
        {
            if (player.GetComponent<PlayerScript>().pickUpList.Any(f => f.pickUpName == PickUpScript.nameType.squashBall))
            {
                reversal *= -1;
            }
            else if (player.GetComponent<PlayerScript>().pickUpList.Any(f => f.pickUpName == PickUpScript.nameType.dimensionPhase)) {

            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        if (thing.name.Contains("player") && reversal == -1 && player.GetComponent<PlayerScript>().pickUpList.Any(f => f.pickUpName == PickUpScript.nameType.boomerang)) {
            Destroy(this.gameObject);
        }

    }
}
