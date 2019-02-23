using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public Transform target;
    private float range;
    public float speed;
    private Animator anim;
    private float currentY;
    private float previousY;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentY = this.transform.position.y;
        previousY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(currentY);
        Debug.Log(previousY);
        Vector3 theScale = transform.localScale;
        range = Vector2.Distance(transform.position, target.position);
        if (this.transform.position.x > target.transform.position.x)
        {
            theScale.x = 1;
            transform.localScale = theScale;
        }
        else
        {
            theScale.x = -1;
            transform.localScale = theScale;
        }
        if (range < 500)
        {

            transform.position = Vector2.MoveTowards(transform.position, target.position, -1*speed * Time.deltaTime);
        }
        GoingUp();
    }
    bool GoingUp()
    {
        previousY = currentY;
        currentY = this.transform.position.y;
        if(currentY > previousY)
        {
            anim.SetBool("isBackwards", true);
            return true;           
        }
        else
        {
            anim.SetBool("isBackwards", false);
            return false;           
        }
    }
}
