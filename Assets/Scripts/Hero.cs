using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
using System;

public class Hero : Entity
{
    [SerializeField] private float speed = 10f;

    private Rigidbody2D rb;
    private UnityArmatureComponent player;
    private bool Move = false;
    private const string NORMAL_ANIMATION_GROUP = "normal";

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponentInChildren<UnityArmatureComponent>();
    }

  

    private void Run()
    {
       
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

        //player.animation.Play("walk");
        if (Move)
            {
            return;
        }
    

        player.animation.FadeIn("hero_walk", 0.01f, -1, 0, NORMAL_ANIMATION_GROUP).resetToPose = false;
      


    }
    private void Update()
    {

        if
            (Input.GetButton("Horizontal"))

        {
            Run(); 
            Move = true;
        }
        else
        {
            Idle();
            Move = false;
        }
       
    }

    private void Idle()
    {
        if (!Move)
        {
            return;
        }


        player.animation.FadeIn("hero_idol", 0.01f, -1, 0, NORMAL_ANIMATION_GROUP).resetToPose = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
    }


}
