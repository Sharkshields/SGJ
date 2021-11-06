using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
using System;

public class Hero : Entity
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private GameObject _parentForFootPrint;

    private ParticleSystem _footPrintObject;
    private Rigidbody2D rb;
    private UnityArmatureComponent player;
    private bool Move = false;
    private const string NORMAL_ANIMATION_GROUP = "normal";


    private bool _isLeafZone;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponentInChildren<UnityArmatureComponent>();
    }

    private void Start()
    {
        player.animation.FadeIn("idle", 0.01f, -1, 0, NORMAL_ANIMATION_GROUP).resetToPose = false;
    }

    private void Run()
    {
       
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        if (!_isLeafZone)
        {
            DestroyParticleFootPrint();
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            player.gameObject.transform.localScale = new Vector3(-0.5f,0.5f,0.5f);
        }
        else 
        {
            player.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        if (Move)
        {
            return;
        }
    
        player.animation.FadeIn("walk", 0.01f, -1, 0, NORMAL_ANIMATION_GROUP).resetToPose = false;

        if (_isLeafZone)
        {
            PlayParticle();
        }
    }
    private void Update()
    {

        if(Input.GetButton("Horizontal"))
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


        player.animation.FadeIn("idle", 0.01f, -1, 0, NORMAL_ANIMATION_GROUP).resetToPose = false;
        DestroyParticleFootPrint();
    }

    

    private void PlayParticle()
    {
        _footPrintObject = Instantiate(Resources.Load<ParticleSystem>("ParticleSystem/LeafForFootprint"),_parentForFootPrint.transform);
    }

    private void DestroyParticleFootPrint()
    {
        if (_footPrintObject != null)
        {
            _footPrintObject.loop = false;
            Destroy(_footPrintObject.gameObject, _footPrintObject.duration);
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<LeafZone>()!=null&&Move)
        {
            _isLeafZone = true;
            PlayParticle();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<LeafZone>() != null)
        {
            _isLeafZone = false;
        }
    }
}
