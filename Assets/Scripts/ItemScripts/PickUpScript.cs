using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public int healthIncrease;
    public int damageIncrease;
    public int speedIncrease;
    public GameObject otherPowerUp1;
    public GameObject otherPowerUp2;
    public GameObject playerObject;
    public int presidence;

    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D thing)
    {
        if (thing.name.Contains("player"))
        {

            applyPowerups();
            destroyObjects();
        }

    }


    private void applyPowerups()
    {
        playerObject.GetComponent<PlayerScript>().maxHealth += healthIncrease;
        playerObject.GetComponent<PlayerScript>().damage += damageIncrease;
        playerObject.GetComponent<PlayerScript>().speed += speedIncrease;
        playerObject.GetComponent<PlayerScript>().pickUpList.Add(this);
    }

    private void destroyObjects()
    {
        Destroy(otherPowerUp1);
        Destroy(otherPowerUp2);
        Destroy(this.gameObject);
    }
}
