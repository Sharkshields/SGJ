using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
