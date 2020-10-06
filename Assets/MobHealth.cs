using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobHealth : MonoBehaviour
{
    private int MaxHealth;
    public int CurrentHealth;
    private int HealthChangeCheck;
    private Animator playerAnimator;
    
    private SpriteRenderer myRenderer;
    private Color colourOne;
    private Color colourTwo;
    private float colourCount = 0;

    public int EditorDamage = 100;
    public bool DamagePlayer = false;
    private bool timerOn = false;

    private bool onlySetOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = 200;
        CurrentHealth = MaxHealth;
        HealthChangeCheck = MaxHealth;

        playerAnimator = gameObject.GetComponent<Animator>();
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        colourOne = myRenderer.material.color;
        colourTwo = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= 0 && onlySetOnce == false)
        {
            playerAnimator.SetTrigger("isDeadTrigger");
            onlySetOnce = true;
        }

        if (DamagePlayer)
        {
            DamagePlayer = false;
            CurrentHealth -= EditorDamage;
        }
    }
}
