using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    private GameObject player;
    private Transform camTransform;
    
    public Camera GameOverCamera;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        camTransform = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x >= 21.76f && player.transform.position.x <= 40.3f)
        {
            camTransform.position = new Vector3(40.3f, camTransform.position.y, camTransform.position.z);
        }
        else if (player.transform.position.x > 164.0067f)
        {
            camTransform.position = new Vector3(player.transform.position.x, camTransform.position.y, camTransform.position.z);
        }
        else if (player.transform.position.x >= 142.9368f)
        {
            camTransform.position = new Vector3(160.2017f, camTransform.position.y, camTransform.position.z);
        }   
        else if (player.transform.position.x >= 118f)
        {
            camTransform.position = new Vector3(camTransform.transform.position.x, camTransform.position.y, camTransform.position.z);
        }
        else if (player.transform.position.x > 40.3f)
        {
            camTransform.position = new Vector3(player.transform.position.x, camTransform.position.y, camTransform.position.z);
        }
        else if (player.transform.position.x < 21.76f)
        {
            camTransform.position = new Vector3(0f, 0f, camTransform.position.z);
        }

        if (player.GetComponent<playerMovement>().rightEdgeReached && player.transform.position.x > 20.32132f)
        {
            player.transform.position = new Vector2(20.32132f, player.transform.position.y);
        }

        if (player.GetComponent<playerMovement>().rightEdgeReached)
        {
            GameObject.Find("GameOver").GetComponent<Animator>().SetBool("isGameOver", true);
            Instantiate(GameOverCamera);
            gameObject.SetActive(false);
        }
    }
}
