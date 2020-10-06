using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeath : StateMachineBehaviour
{
    private GameObject player;
    private playerMovement playerMoveScript;
    public Camera GameOverCamera;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.gameObject;
        playerMoveScript = player.GetComponent<playerMovement>();
        animator.SetBool("isDead", true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerMoveScript.XmovementSpeedFinal = 0;
        playerMoveScript.YmovementSpeedFinal = 0;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject.Find("GameOver").GetComponent<Animator>().SetBool("isGameOver", true);
        Instantiate(GameOverCamera);
        GameObject.Find("Main Camera").SetActive(false);
    }
}
