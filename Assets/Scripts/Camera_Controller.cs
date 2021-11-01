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
        pos.z = -10f; // ����� ������ �� ��� Z �� ���������
        pos.y += 1f;

        transform.position = Vector3.Lerp(transform.position, pos, 3 * Time.deltaTime); //Lerp �������� �� �������� ������. ��������� � deltaTime ������ �������� �������� ������
    }
}
