﻿
using UnityEngine;

public class SinglePlayerControler : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 10f;


    void Update()

    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);


    }

}