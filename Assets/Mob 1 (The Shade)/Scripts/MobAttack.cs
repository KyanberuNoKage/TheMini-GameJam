using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAttack : MonoBehaviour
{
    private RayCastUtilScript util;

    private GameObject me;
    private Transform myTransform;
    public GameObject player;
    private Animator myAnimator;

    private float timer = 0;
    private bool attackHit = false;

    public LayerMask playerMask;

    // Start is called before the first frame update
    void Start()
    {
        util = GameObject.Find("Utility_Object").GetComponent<RayCastUtilScript>();

        me = gameObject;
        myTransform = me.transform;
        myAnimator = me.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 attackOffset = new Vector2(-5.27f, 6.43f);
        
        if (timer < 6)
        {
            timer += Time.deltaTime;
        }

        Vector2 offset = new Vector2(-8.6f, 7.5f);

        if (util.InRange((Vector2)myTransform.position + offset, Vector2.left, 10, playerMask, "Player", "tag"))
        {
            myAnimator.SetBool("playerDetected", true);
        }
        else if(!util.InRange((Vector2)myTransform.position + offset, Vector2.left, 10, playerMask, "Player", "tag"))
        {
            myAnimator.SetBool("playerDetected", false);
        }

        if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("shadePlayerDetected"))
        {
            if (timer >= 4)
            {
                timer = 0;
                attackHit = false;
                myAnimator.SetTrigger("attackTrigger");
            }
        }

        if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("shadeAttack"))
        {
            if (attackHit == false && util.InRange((Vector2)myTransform.position + attackOffset, Vector2.left, 6.77f, playerMask, "Player", "tag"))
            {
                if (timer > 0.75 && !(GameObject.Find("player").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("playerBlock")))
                {
                    GameObject.Find("player").GetComponent<PlayerHealth>().CurrentHealth -= 150;
                    attackHit = true;
                    timer = 0;
                }
            }
        }
    }
}
