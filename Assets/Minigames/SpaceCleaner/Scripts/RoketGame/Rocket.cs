using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float velocity;
    private Rigidbody2D rigidbody;
    private float x_Min, x_Max;
    public event Action<int> OnGrabGarbage;
    public event Action OnDie;
    

    void Start()
    {
        Time.timeScale = 1;
        rigidbody = GetComponent<Rigidbody2D>();
        x_Min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        x_Max = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
    }

    void FixedUpdate()
    {
        Vector2 dir = new Vector2(Input.GetAxis("Horizontal"),0);
        //Vector2 dir = Input.acceleration;
        Vector2 targetPosition = new Vector2(Mathf.Clamp(rigidbody.position.x + dir.x, x_Min + 0.2f, x_Max - 0.2f), 1);
        rigidbody.position = Vector2.Lerp(rigidbody.position, targetPosition, Time.fixedDeltaTime * velocity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Asteroid>()!=null)
        {
            Time.timeScale = 0;

            OnDie();
            
        }
        if (collision.gameObject.GetComponent<Garbage>()!=null)
        {
            int score = collision.gameObject.GetComponent<Garbage>().Count;
            OnGrabGarbage(score);
        }
    }
   
    
   
}
