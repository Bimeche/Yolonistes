﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private Animator animator;                  //Used to store a reference to the Player's animator component.          
    private Rigidbody2D rbody;
    public Timer t;
    //Start overrides the Start function of MovingObject
    protected void Start()
    {
        //Get a component reference to the Player's animator component
        animator = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(movement_vector != Vector2.zero)
        {
            animator.SetBool("isWalking", true);
            animator.SetFloat("input_x", movement_vector.x);
            animator.SetFloat("input_y", movement_vector.y);

        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        rbody.MovePosition(rbody.position + movement_vector / 10);

        if (Input.GetKeyDown(KeyCode.A) )
        {
            t.ChangeTime(0, 10);
        }
    }
}
