using System;
using System.Collections;
using UnityEngine;

public class InputForPlayer : MonoBehaviour
{
    public float AxisHorizontal { get; set; }
    
    void Update()
    {
        AxisHorizontal = Input.GetAxis("Horizontal");
    }
}
