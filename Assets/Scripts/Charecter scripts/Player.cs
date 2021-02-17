﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player player;
    [SerializeField] private ShootingScript shooting;
    [SerializeField] private HealthController health;

    private void Start()
    {
        player = this;
    }

    public void ActivateShooting()
    {
        shooting.enabled = true;
        Time.timeScale = 1;
    }

    public void DeactivateShooting()
    {
        shooting.enabled = false;
        Time.timeScale = 0;
    }

    public void ApplyDamage(int amount) => health.AddDamage(amount);

    public void ApplyHealing(int amount) => health.AddHeal(amount);
}