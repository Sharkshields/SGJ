using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 pos;

    private void Awake()
    {
        if (!player)
            player = FindObjectOfType<Hero>().transform;
    }

    // Update is called once per frame
    private void Update()
    {
        pos = player.position;
        pos.z = -10f; // „тобы камера по оси Z не двигалась
        pos.y = 0f; // „тобы камера по оси Y не двигалась


        //pos.y += 1f;

        transform.position = Vector3.Lerp(transform.position, pos, 3 * Time.deltaTime); //Lerp отвечает за движение камеры. ћножитель к deltaTime мен€ет скорость движени€ камеры
    }
}
