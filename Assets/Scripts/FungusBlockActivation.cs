using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FungusBlockActivation : MonoBehaviour
{
    public Fungus.Flowchart myFlowchart;
    private Hero player;

    [SerializeField] private string targetBlock;
    [SerializeField] private bool deleteTrigger;
    [SerializeField] private bool onInteraction;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.GetComponent<Hero>();
        if (!onInteraction)

        { if (collision.gameObject.tag == "Player")
            {
                Debug.Log("Triggered");
                myFlowchart.ExecuteBlock(targetBlock);
                if (deleteTrigger)
                    Destroy(this);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetButtonDown("Use") && onInteraction)
        {
            myFlowchart.ExecuteBlock(targetBlock);
            if (deleteTrigger)
                Destroy(this);
        }
    }

}
