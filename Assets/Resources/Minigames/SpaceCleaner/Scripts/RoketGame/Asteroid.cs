using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float _velocity;
    private Rigidbody2D rigidbody;
    private float velocity;
    
    private void Awake()
    {
        velocity = Random.Range(-150, -200);
        rigidbody = this.GetComponent<Rigidbody2D>();
    }
    void OnEnable()
    {
        velocity -= _velocity;
        rigidbody.AddForce(new Vector2(0,velocity ));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

}
