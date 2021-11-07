using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRocket : MonoBehaviour
{
    [SerializeField] private Save save;
    private Rocket player;
    public event Action<Rocket> OnGetRocket;

    private void Awake()
    {
        Vector2 spawn_position = new Vector2(0, 0);
        Quaternion spawn_rotator = Quaternion.identity;
        player = Instantiate(save.Roket, this.transform);
        OnGetRocket(player);
    }


}
