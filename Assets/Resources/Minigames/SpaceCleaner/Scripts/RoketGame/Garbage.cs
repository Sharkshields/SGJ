using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    
    [SerializeField]private int count;
    private Rigidbody2D rigidbody;

    public int Count { get => count;}

    private void Awake()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
    }
    void OnEnable()
    {
        rigidbody.AddForce(new Vector2(0, Random.Range(-100, -150)));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Rocket>()!=null)
        {
            gameObject.SetActive(false);
        }
    }
}
