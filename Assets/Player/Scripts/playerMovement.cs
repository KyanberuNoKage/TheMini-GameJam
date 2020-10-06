using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private RayCastUtilScript RayScript;

    private GameObject player;
    private Transform attackTransform;
    public GameObject attackObj;
    private Transform playerTransform;
    private Rigidbody2D playerRB2D;
    private Animator playerAnimator;

    private float top_Edge = -7.8f;
    private float bottom_Edge = -11.2f;
    private int moveDirectionX;
    private int moveDirectionY;
    public float XmovementSpeed = 0.1f;
    public float YmovementSpeed = 0.05f;
    public float XmovementSpeedFinal;
    public float YmovementSpeedFinal;
    private bool canAttack = true;
    public bool triggerOne;

    private bool attackHasHit;
    public GameObject ObjectHit;
    public LayerMask enemyLayer;

    private bool hasAttacked = false;

    public bool rightEdgeReached;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject;
        playerAnimator = player.GetComponent<Animator>();
        playerTransform = player.transform;
        playerRB2D = player.GetComponent<Rigidbody2D>();
        RayScript = GameObject.Find("Utility_Object").GetComponent<RayCastUtilScript>();
        attackTransform = attackObj.transform;
        rightEdgeReached = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.x >= 255.31f)
        {
            playerTransform.position = new Vector2(-17.5f, playerTransform.position.y);
            rightEdgeReached = true;
        }
        attackRay();
        #region Idle Reset
        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("playerIdle"))
        {
            hasAttacked = false;
        }
        #endregion
        #region Movement Calculation
        XmovementSpeedFinal = (float)Screen.width * XmovementSpeed;
        YmovementSpeedFinal = (float)Screen.width * YmovementSpeed;
        #endregion
        #region Player Attack
        if (Input.GetKey(KeyCode.Mouse0) && canAttack)
        {
            playerAnimator.SetTrigger("attackTrigger");
            canAttack = false;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            canAttack = true;
        }

        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("playerAttack"))
        {
            XmovementSpeedFinal = 0;
            YmovementSpeedFinal = 0;
        }
        #endregion
        #region Player Block
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            playerAnimator.SetTrigger("blockTrigger");
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            playerAnimator.SetTrigger("blockTrigger");
        }

        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("playerBlock"))
        {
            XmovementSpeedFinal = 0;
            YmovementSpeedFinal = 0;
        }
        #endregion
        getMoveInput();
        #region Player Walk (anim)
        if (moveDirectionX != 0 || moveDirectionY != 0)
        {
            playerAnimator.SetInteger("movement", 1);
        }
        #endregion
        #region Left Edge
        if (player.transform.position.x < -17.42f)
        {
            playerTransform.position = new Vector3(-17.42f, playerTransform.position.y, playerTransform.position.z);
        }

        #endregion
        move();
        #region playerAreaCheck
        if (playerTransform.position.y > top_Edge)
        {
            playerTransform.position = new Vector3(playerTransform.position.x, top_Edge, playerTransform.position.z);
        }

        if (playerTransform.position.y < bottom_Edge)
        {
            playerTransform.position = new Vector3(playerTransform.position.x, bottom_Edge, playerTransform.position.z);
        }
        #endregion
    }

    void getMoveInput()
    {
        if (!playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("playerAttack")) {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                moveDirectionX = 1;
                #region Set Rotation
                playerTransform.eulerAngles = new Vector2(playerTransform.eulerAngles.x, 0);
                #endregion
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                moveDirectionX = -1;
                #region Set Rotation
                playerTransform.eulerAngles = new Vector2(playerTransform.eulerAngles.x, 180);
                #endregion
            }
            else
            {
                moveDirectionX = 0;
                #region set animation
                playerAnimator.SetInteger("movement", 0);
                #endregion
            }

            if (Input.GetAxisRaw("Vertical") > 0 && playerTransform.position.y < top_Edge)
            {
                moveDirectionY = 1;
            }
            else if (Input.GetAxisRaw("Vertical") < 0 && playerTransform.position.y > bottom_Edge)
            {
                moveDirectionY = -1;
            }
            else
            {
                moveDirectionY = 0;
                #region set animation
                playerAnimator.SetInteger("movement", 0);
                #endregion
            }

            #region Trigger One
            if (Input.GetAxisRaw("Horizontal") < 0 && playerTransform.position.x <= 26.5f && triggerOne == true)
            {
                Debug.Log("Player Movement Stoped");
                moveDirectionX = 0;
            }
            #endregion
        }
    }

    void move()
    {
        Vector2 newPosition = new Vector2(moveDirectionX * XmovementSpeedFinal, moveDirectionY * YmovementSpeedFinal);
        playerRB2D.MovePosition((Vector2)playerTransform.position + (newPosition * Time.deltaTime));
    }

    void attackRay()
    {
        if (InRange(attackTransform.position, Vector2.right, 2.64f, enemyLayer, "enemy", "tag"))
        {
            if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("playerAttack"))
            {
                damageEnemy();
            }
        }
    }

    #region public bool InRange()
    public bool InRange(Vector2 position, Vector2 direction, float distance, LayerMask mask, string colliderNameOrTag, string Name_Or_Tag)
    {
        RaycastHit2D ray = Physics2D.Raycast(position, direction, distance, mask);

            Debug.DrawRay(position, direction * distance, Color.green);

        /*Check wether a name or a tag needs to be checked for.
        If Name_Or_Tag is 1, the name will be checked, if 0, the tag will be checked.
        If an int value above 1 or below 0 is given the method will return false.*/
        switch (Name_Or_Tag)
        {
            case "name":
                if (ray.collider != null)
                {
                    if (ray.collider.name == colliderNameOrTag)
                    {
                        ObjectHit = ray.collider.gameObject;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            case "tag":
                if (ray.collider != null)
                {
                    if (ray.collider.CompareTag(colliderNameOrTag))
                    {
                        ObjectHit = ray.collider.gameObject;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            default:
                return false;
        }
    }
    #endregion

    void damageEnemy()
    {
        if (hasAttacked == false)
        {
            ObjectHit.GetComponent<MobHealth>().CurrentHealth -= 100;
            hasAttacked = true;
        }
        
        
    }
}
