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
    private float xMin, xMax, yPos;
    public event Action<int> OnGrabGarbage;
    public event Action OnDie;
    

    void Start()
    {
        yPos = gameObject.transform.position.y;
        Time.timeScale = 1;
        rigidbody = GetComponent<Rigidbody2D>();
        xMin = -3;
        xMax = 3;
    }

    void FixedUpdate()
    {
        Vector2 dir = new Vector2(Input.GetAxis("Horizontal"),0);
        //Vector2 dir = Input.acceleration;
        Vector2 targetPosition = new Vector2(Mathf.Clamp(rigidbody.position.x + dir.x, xMin + 0.2f, xMax - 0.2f), yPos);
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
