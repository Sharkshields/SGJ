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

    private InputForPlayer _input;

    private bool _isLeafZone;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponentInChildren<UnityArmatureComponent>();
        AddInput();
    }


    private void AddInput()
    {
        _input = new GameObject("InputHero").AddComponent<InputForPlayer>();
    }
  
    public void DestroyInput()
    {
        Destroy(_input.gameObject);
        _input = null;
    }

    private void Run(float axis)
    {
       
        Vector3 dir = transform.right * axis;

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

    private void LateUpdate()
    {
        if (_input!=null)
        {
            if (_input.AxisHorizontal!=0)
            {

                Run(_input.AxisHorizontal);
                Move = true;
            }
            else
            {
                Idle();
                Move = false;
            }
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
