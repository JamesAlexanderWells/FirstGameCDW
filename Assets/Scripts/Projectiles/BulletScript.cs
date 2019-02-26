using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    public float speed;
    public List<PickUpScript> pickUpList = new List<PickUpScript>();
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
    // Use this for initialization
    void Start()
    {
        initializationTime = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement();
        returnBullet();
        timeOut();
    }

    void timeOut() {
        if ( 3 <= Time.timeSinceLevelLoad - initializationTime) {
            Destroy(this.gameObject);
        }
    }

    void returnBullet()
    {
        if (1.5 <= Time.timeSinceLevelLoad - initializationTime)
        {
            reversal = -1;
        }
    }

    void movement()
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

    void OnTriggerEnter2D(Collider2D thing)
    {
        if (thing.name.Contains("Wall"))
        {
            if (pickUpList.Any(f => f.pickUpName == PickUpScript.nameType.squashBall))
            {
                reversal *= -1;
            }
            else if (pickUpList.Any(f => f.pickUpName == PickUpScript.nameType.dimensionPhase)) {

            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        if (thing.name.Contains("player") && reversal == -1 && ) {
            Destroy(this.gameObject);
        }

    }
}
