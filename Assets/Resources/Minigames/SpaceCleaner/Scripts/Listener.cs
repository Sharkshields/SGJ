using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Listener : MonoBehaviour
    {
        public InteractionWithObject OnInteract;

        private void Awake()
        {
            OnInteract.OnInteract += LOnInteract;
        }

        private void LOnInteract(GameObject obj)
        {
            
        }
    }
}