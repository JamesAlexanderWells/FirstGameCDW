using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    private Animator anim;
    public float speed;
    public float damage;
    private bool wallFreeN = true;
    private bool wallFreeS = true;
    private bool wallFreeW = true;
    private bool wallFreeE = true;
    public GameObject bullet;
    public GameObject pauseCanvas;
    public GameObject deathCanvas;
    public int maxHealth;
    public int currentHealth;
    public float fireRate;
    private float nextFire;
    public List<PickUpScript> pickUpList = new List<PickUpScript>();
    Vector3 startPos;
    public Rigidbody2D playerRigidbody2D;
    private bool isShowing = false;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        pauseCanvas.SetActive(isShowing);
        deathCanvas.SetActive(false);
        anim = GetComponent<Animator>();
        startPos = this.transform.position;
        playerRigidbody2D.freezeRotation = true;
        currentHealth = maxHealth;
    }


 

    void FixedUpdate()
    {
        
        anim.SetBool("ifwalk", false);
        anim.SetBool("shoot", false);
        anim.SetBool("walkdown", false);
        anim.SetBool("shootdown", false);
        playerMovement();
        playerShooting();
        PlayerDeath();
    }

    private void Update()
    {
        PauseGame();
    }



    private void PauseGame() {
        if (Input.GetKeyDown("escape") )
        {
            isShowing = !isShowing;
            pauseCanvas.SetActive(!pauseCanvas.active);
            if (pauseCanvas.active)
            {
                Time.timeScale = 0;
            }
            else {
                Time.timeScale = 1;
            }
        }

    }

    private void playerShooting()
    {
        Vector3 theScale = transform.localScale;
        if (Input.GetKey(KeyCode.LeftArrow) && Time.time > nextFire)
        {
            theScale.x = 1;
            transform.localScale = theScale;
            anim.SetBool("shoot", true);
            GameObject bullet = Instantiate(this.bullet, transform.position - new Vector3(1, 0, 0), Quaternion.identity);
            nextFire = Time.time + fireRate;
            //bullet.transform.position = transform.position;
            bullet.GetComponent<BulletScript>().way = BulletScript.direction.west;
        }
        if (Input.GetKey(KeyCode.RightArrow) && Time.time > nextFire)
        {
            theScale.x = -1;
            transform.localScale = theScale;
            anim.SetBool("shoot", true);
            GameObject bullet = Instantiate(this.bullet, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
            nextFire = Time.time + fireRate;
            //bullet.transform.position = transform.position;
            bullet.GetComponent<BulletScript>().way = BulletScript.direction.east;

        }
        if (Input.GetKey(KeyCode.UpArrow) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject bullet = Instantiate(this.bullet, transform.position, Quaternion.identity);
            bullet.transform.position = transform.position;
            bullet.GetComponent<BulletScript>().way = BulletScript.direction.north;
        }
        if (Input.GetKey(KeyCode.DownArrow) && Time.time > nextFire)
        {
            anim.SetBool("shootdown", true);
            nextFire = Time.time + fireRate;
            GameObject bullet = Instantiate(this.bullet, transform.position, Quaternion.identity);
            bullet.transform.position = transform.position;
            bullet.GetComponent<BulletScript>().way = BulletScript.direction.south;
        }

    }





    private void playerMovement()
    {
        Vector3 theScale = transform.localScale;
        float y = 0;
        float x = 0;

        if (Input.GetKey(KeyCode.A))
        {
            if (wallFreeW)
            {
                x -= speed;
                if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow))
                {
                    anim.SetBool("ifwalk", true);
                    theScale.x = 1;
                    transform.localScale = theScale;
                }
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (wallFreeE)
            {
                x += speed;
                if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow))
                {
                    anim.SetBool("ifwalk", true);
                    theScale.x = -1;
                    transform.localScale = theScale;
                }
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (wallFreeN)
            {
                y += speed;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (wallFreeS)
            {
                if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow))
                    {
                    anim.SetBool("walkdown", true);
                }
                y -= speed;
            }
        }
        playerRigidbody2D.velocity = new Vector3(x, y, 0);
    }

    void PlayerDeath() {
        if (currentHealth <= 0) {
            deathCanvas.SetActive(true);
            Time.timeScale = 0;
        }

    }

}
