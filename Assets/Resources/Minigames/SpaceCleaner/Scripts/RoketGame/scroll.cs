using System;
using System.Collections.Generic;
using UnityEngine;


public class scroll : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public float speed;
    float L_Size;
    float L_Poss;
   

    void Start()
    {
        rigidbody2D = this.GetComponent<Rigidbody2D>();
        L_Size = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        Scroll();
    }

    private void Scroll()
    {
        L_Poss += speed * Time.deltaTime;
        L_Poss = Mathf.Repeat(L_Poss, L_Size);
        rigidbody2D.MovePosition(new Vector2(0,L_Poss));
    }

}
