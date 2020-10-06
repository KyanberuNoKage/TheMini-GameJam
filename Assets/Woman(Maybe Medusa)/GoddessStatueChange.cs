using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoddessStatueChange : MonoBehaviour
{
    public bool isStatueState = false;
    private Animator myAnimator;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = gameObject.GetComponent<Animator>();
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isStatueState)
        {
            myAnimator.SetBool("isStatue", true);
        }
        else if (!isStatueState)
        {
            myAnimator.SetBool("isStatue", false);
        }

        if (player.GetComponent<playerMovement>().rightEdgeReached)
        {
            isStatueState = true;
            GameObject.Find("textThing").transform.position = new Vector2(0f,-100f);
        }
    }
}
