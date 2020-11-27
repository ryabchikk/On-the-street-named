﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Скрипт для объекта который будет вызывать какуро
//На объекте добавить триггер коллайдер в который нужно будет зайти чтобы начать

public class TestBox : MonoBehaviour
{
    [SerializeField]
    private GameObject board;               //В инспекторе сюда префаб доски
    [SerializeField]
    private GameObject player;
    private ShootingScript ShootActivation;
    private void Start()
    {
        ShootActivation = player.GetComponent<ShootingScript>();
    }
    private void OnTriggerStay(Collider other)
    {
            if ((Input.GetKeyDown("e"))&&(other.CompareTag("Player"))) 
            { 
                StartTest(other.gameObject);
                ShootActivation.enabled = false;
                Time.timeScale = 0;
            }
    }

    private void StartTest(GameObject player)
    {
        player.SendMessage("MinigameState", true);
        Instantiate(board);
    }
}