using UnityEngine;

public class Mantis : MonoBehaviour
{
    public Transform target;
    private SpriteRenderer sprite;
    private float range;
    public float speed;
    private Animator anim;
    private float rangex;
    private float rangey;
    public float shootTimer;
    private float shootcountdown;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        shootcountdown = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("attack", false);
        anim.SetBool("attackdown", false);
        Vector3 theScale = transform.localScale;
        range = Vector2.Distance(transform.position, target.position);
        rangex = transform.position.x - target.position.x;
        rangey = transform.position.y - target.position.y;
        if (this.transform.position.x > target.transform.position.x)
        {
            theScale.x = 2;
            transform.localScale = theScale;
        }
        else
        {
            theScale.x = -2;
            transform.localScale = theScale;
        }
        if (rangey < 2)
        {
            sprite.sortingOrder = 2;
        }
        else
        {
            sprite.sortingOrder = 0;
        }
        if (rangex > 3 || rangey > 4 || -rangex > 3 || -rangey > 4)
        {
            if (!this.anim.GetCurrentAnimatorStateInfo(0).IsName("shoot"))
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        }
        if (range <= 5f)
            if (rangex > rangey - 2 || -rangex > rangey - 2)
            {

                anim.SetBool("attack", true);
            }
            else if(rangey <= 5)
            {
                anim.SetBool("attackdown", true);
            }
        if (Time.time - shootcountdown > shootTimer)
        {
            anim.SetBool("shoot", true);
            shootcountdown = Time.time;
        }
        else
        {
            anim.SetBool("shoot", false);
        }
        

    }
}
