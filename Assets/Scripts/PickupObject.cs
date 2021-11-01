using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{

    public GameObject guiObject;

    void Start()
    {
        guiObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
          
            guiObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (guiObject.activeInHierarchy == true && Input.GetButtonDown("Use"))
        {
            print("Item picked up");
            Destroy(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        guiObject.SetActive(false);


    }
}
