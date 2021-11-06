using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionWithObject : MonoBehaviour
{
    [SerializeField] private GameObject text;
    private Hero player;

    public event Action<Hero> OnInteract;

    private void Awake()
    {
        text = FindObjectOfType<TextForUsed>().gameObject;
        text.gameObject.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        text.gameObject.SetActive(true);
        player = collision.GetComponent<Hero>();

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        text.gameObject.SetActive(false);
        player = null;
    }

    void Interaction()
    {
        if (player == null) { }
        OnInteract(player);
    }

    private void ListenerOnInteract()
    {

    }

    private void Update()
    {
        if (Input.GetButtonDown("Use"))
        {
            Interaction();
        }
    }
}