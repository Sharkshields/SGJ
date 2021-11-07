using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class InteractionWithObject : MonoBehaviour
    {

        private Text text;
        private GameObject player;

        public event Action<GameObject> OnInteract;

        InputField input;

        private void Awake()
        {
            
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            text.text = "";
            player = collision.GetComponent<GameObject>();

        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            text.text = "";
            player = null;
        }

        void Interaction()
        {
            if (player == null)
                OnInteract(player);
        }

        private void ListenerOnInteract()
        {
            
        }

         

    }
}