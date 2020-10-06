using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int MaxHealth;
    public int CurrentHealth;
    private int HealthChangeCheck;
    private Animator playerAnimator;

    public int EditorDamage = 100;
    public bool DamagePlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = 1000;
        CurrentHealth = MaxHealth;
        HealthChangeCheck = MaxHealth;
        playerAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth != HealthChangeCheck)
        {
            HealthChangeCheck = CurrentHealth;
        }

        if (CurrentHealth <= 0)
        {
            playerAnimator.SetTrigger("isDeadTrigger");
        }

        if (DamagePlayer)
        {
            DamagePlayer = false;
            CurrentHealth -= EditorDamage;
        }
    }
}
