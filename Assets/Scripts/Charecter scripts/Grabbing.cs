using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbing : MonoBehaviour
{
    
    public float grabPower = 10.0f;
    public float throwPower = 10f;   //скорость толчка
    public float RayDistance = 30.0f;   //дистанция
    private bool Grab = false;   //ф-ция притяжения
    private int count = 0;
    public Transform offset;
    RaycastHit hit;   //луч
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Physics.Raycast(new Ray(gameObject.transform.position + new Vector3(0, -2, 0), gameObject.transform.forward), out hit, RayDistance);
            if (hit.rigidbody)
            {
               Grab = true;      
            }
            Debug.Log(count);
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
            }
        }
    }
    //ф-ия толчка
    private void Trow() 
    {
        if (hit.rigidbody)
        {
            hit.rigidbody.velocity = gameObject.transform.forward * throwPower;
        }
    }
}
