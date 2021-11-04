using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FungusBlockActivation : MonoBehaviour
{
    public Fungus.Flowchart myFlowchart;
    [SerializeField] private string targetBlock;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Triggered");
            myFlowchart.ExecuteBlock(targetBlock);
        }
    }

}