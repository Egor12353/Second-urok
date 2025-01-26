using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class going : MonoBehaviour
{
    public Transform gb;
    private Transform rot;
    [SerializeField]
    private float speed = 0.01f;
    [SerializeField]
    private float rotationSpeed = 10f;
    private bool timera = false; 
    
    void Update()
    {


        if (Input.GetKey(KeyCode.W))
        {
            
            Vector3 de = new Vector3(gb.position.x, gb.position.y, gb.position.z + speed);
            gb.position = de;

        }
        if (Input.GetKey(KeyCode.D))
        {
            
            Vector3 de = new Vector3(gb.position.x + speed, gb.position.y, gb.position.z);
            gb.position = de;


        }
        if (Input.GetKey(KeyCode.A))
        {
            
            Vector3 de = new Vector3(gb.position.x - speed, gb.position.y, gb.position.z);
            gb.position = de;

        }

        if (Input.GetKey(KeyCode.S))
        {
            
            Vector3 de = new Vector3(gb.position.x, gb.position.y, gb.position.z - speed);
            gb.LocalPosition = de;
            print(de);
        }

        if (Input.GetMouseButtonDown(0))
        {
            timera = true;
            if (timera == true)
            {
                gb.rotation *= Quaternion.Euler(0, rotationSpeed, 0);
            }
        }


        }
    }
