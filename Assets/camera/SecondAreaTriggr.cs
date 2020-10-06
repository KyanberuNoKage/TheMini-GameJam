using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondAreaTriggr : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.name == "player")
        {
            collider2D.gameObject.GetComponent<playerMovement>().triggerOne = true;
            Debug.Log(collider2D.gameObject.name + " hit trigger");
        }
    }
}
