﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int shieldHealth;
    [SerializeField] private bool isHit;

    [SerializeField] private float invincibilityTime;
    [SerializeField] private float currentTimer;
    // Start is called before the first frame update
    void Start()
    {
        currentTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Sets the shield health to 0 if the value goes under 0
        if (shieldHealth <= 0)
        {
            shieldHealth = 0;
        }

        //If the player was hit, start a timer in which the player will be immune to all other types of damage within the set timeframe
        //Stops timer and resets it to 0 if the alloted time is reached
        if (isHit)
        {
            currentTimer += Time.deltaTime;

            if (currentTimer >= invincibilityTime)
            {
                isHit = false;
                currentTimer = 0;
            }
        }

    }

    //Function that handles damaging the player based on the incoming damage value if they have not been hit recently (Depending on the invincibility time)
    public void damagePlayer(int incomingDamage)
    {
        if (!isHit)
        {
            shieldHealth -= incomingDamage;
            isHit = true;
        }

    }
}