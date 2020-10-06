using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    private GameObject player;
    private GameObject me;
    private Animator myAnimator;
    private Rigidbody2D myRB2D;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        myAnimator = gameObject.GetComponent<Animator>();
        me = gameObject;
        myRB2D = me.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Timer
        timer = Time.deltaTime;

        if (player.GetComponent<playerMovement>().rightEdgeReached)
        {
            myAnimator.SetBool("isWalking", true);
            if (me.transform.position.x <= 0)
            {
                myRB2D.MovePosition(new Vector2(1f, 0f) * Time.deltaTime * player.GetComponent<playerMovement>().XmovementSpeedFinal);
            }
            
            timer = 0;
            if (timer == 1)
            {
                me.transform.eulerAngles = new Vector2(me.transform.eulerAngles.x, 180);
            }
            //THE STUFF
        }
    }
}
