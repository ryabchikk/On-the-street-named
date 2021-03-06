﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbing : MonoBehaviour
{
    public float grabPower = 10.0f;
    public float throwPower = 10f;   //скорость толчка
    public float RayDistance = 30.0f;   //дистанция
    private bool Grab = false;   //ф-ция притяжения
    public Transform offset;
    RaycastHit hit;   //луч


    private void Start()
    {}
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Physics.Raycast(new Ray(gameObject.transform.position + new Vector3(0, -2, 0), gameObject.transform.forward), out hit, RayDistance);
            if (hit.rigidbody)
            {
                Grab = true;
            }
        }
        //если нажата левая  кнопка мыши
        if (Input.GetMouseButtonDown(0))
        {
            if (Grab)
            {
                Grab = false;
                Trow();
            }
        }
        //ф-ция притяжения
        if (Grab)
        {
            if (hit.rigidbody)
            {
                hit.rigidbody.velocity = (offset.position - (hit.transform.position + hit.rigidbody.centerOfMass)) * grabPower;
                hit.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                hit.rigidbody.freezeRotation = true;
            }
        }
    }
    //ф-ия толчка
    private void Trow() 
    {
        if (hit.rigidbody)
        {
            hit.rigidbody.velocity = gameObject.transform.forward * throwPower;
            hit.rigidbody.freezeRotation = false;
        }
    }
}
