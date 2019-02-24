using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public enum nameType
    {
        fireBall,
        bear,
        kawabunga,
    };

    public int healthIncrease;
    public int damageIncrease;
    public int speedIncrease;
    public GameObject otherPowerUp1;
    public GameObject otherPowerUp2;
    public GameObject playerObject;
    public int presidence;
    public GameObject bullet;
    public GameObject spriteList;
    public SpriteRenderer ownSprite;
    public nameType pickUpName;

    // Use this for initialization
    void Start()
    {

        Array values = Enum.GetValues(typeof(nameType));
        System.Random random = new System.Random();
        pickUpName = (nameType)values.GetValue(random.Next(values.Length));





        while (otherPowerUp1.GetComponent<PickUpScript>().pickUpName == this.pickUpName || otherPowerUp2.GetComponent<PickUpScript>().pickUpName == this.pickUpName)
        {
            pickUpName = (nameType)values.GetValue(random.Next(values.Length));
        }
        setSprite();
    }


    void setSprite()
    {
        switch (pickUpName)
        {
            case nameType.fireBall:
                ownSprite.sprite = spriteList.GetComponent<PickUpSpriteList>().fireBall;
                break;
            case nameType.bear:
                ownSprite.sprite = spriteList.GetComponent<PickUpSpriteList>().bear;
                break;
            case nameType.kawabunga:
                ownSprite.sprite = spriteList.GetComponent<PickUpSpriteList>().kawabunga;
                break;
        }

    }

    void OnTriggerEnter2D(Collider2D thing)
    {
        if (thing.name.Contains("Player"))
        {

            applyPowerups();
            destroyObjects();
        }

    }


    private void applyPowerups()
    {
        switch (pickUpName)
        {
            case nameType.fireBall:
                //ownSprite.sprite = spriteList.GetComponent<sprites>().fireBall;
                break;
            case nameType.bear:
                //ownSprite.sprite = spriteList.GetComponent<sprites>().bear;
                playerObject.GetComponent<PlayerScript>().maxHealth += 10;
                break;
            case nameType.kawabunga:
                playerObject.GetComponent<PlayerScript>().speed += 10;
                break;
        }

        playerObject.GetComponent<PlayerScript>().pickUpList.Add(this);
    }

    private void destroyObjects()
    {
        Destroy(otherPowerUp1);
        Destroy(otherPowerUp2);
        Destroy(this.gameObject);
    }
}
