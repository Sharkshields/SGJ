using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class Hero : Entity
{
    [SerializeField] private float speed = 10f;

    private Rigidbody2D rb;
    private UnityArmatureComponent player;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponentInChildren<UnityArmatureComponent>();
    }

  

    private void Run()
    {
       
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

        player.animation.Play(("walk"));


    }
    private void Update()
    {
       
        if (Input.GetButton("Horizontal"))
                Run();
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
    }


}
