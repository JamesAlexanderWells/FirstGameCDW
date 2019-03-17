using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : BossScript
{
    private float range;
    // Start is called before the first frame update
    void Start()
    {
        
        Target = GameObject.Find("dummyPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Death();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        TakeDamage(col);
        DealDamage(col);
    }

    public override void Movement()
    {
        range = Vector2.Distance(transform.position, Target.transform.position);

        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, Speed * Time.deltaTime);
    }
}
