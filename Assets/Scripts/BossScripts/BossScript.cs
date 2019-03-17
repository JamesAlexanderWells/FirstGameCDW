using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public float Health;
    public int Damage;
    public float Speed;
    public float Aggresion;
    public float Size;
    public GameObject Target;
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Attack();
        Death();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        TakeDamage(col);
        DealDamage(col);
    }

    
    public virtual void Movement()
    {

    }
    
    public void Attack()
    {

    }

    public void TakeDamage(Collider2D col)
    {
        if (col.name.Contains("Bullet") && col.name.Contains("Clone"))
        {
            Health -= player.GetComponent<PlayerScript>().damage;
        }
    }
    public void DealDamage(Collider2D col)
    {
        if (col.name.Contains("Player"))
        {
            player.GetComponent<PlayerScript>().currentHealth -= Damage;
        }
    }
    public void Death()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }

    }
    public void KnockBack()
    {

    }
}
