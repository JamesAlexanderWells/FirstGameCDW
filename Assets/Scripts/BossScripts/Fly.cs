using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : BossScript
{
    private float range;
    public GameObject self;
    private float SplitTimer;
    public float SplitCounter;
    // Start is called before the first frame update
    void Start()
    {
        if (name.Contains("Clone"))
        {
            SplitCounter = 0;
        }
        Target = GameObject.Find("dummyPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        Splitting();
        Movement();
        Death();
        KnockbackCooldown();

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        TakeDamage(col);
        DealDamage(col);
    }

    public override void Movement()
    {
        range = Vector2.Distance(transform.position, Target.transform.position);
        if (!Knockback)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, Speed * Time.deltaTime);
            var dir = Target.transform.position - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, -KnockbackSpeed*5 * Time.deltaTime);
        }
    }
    private void Splitting()
    {
        if (Split && (Time.time-SplitTimer > 2) && (SplitCounter > 0))
        {

            GameObject fly = Instantiate(self,new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

            SplitTimer = Time.time;
            SplitCounter -= 1;
            Split = false;
        }
    }
}
