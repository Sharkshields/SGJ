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
        pos.z = -10f; // ����� ������ �� ��� Z �� ���������
        pos.y = 1f; // ����� ������ �� ��� Y �� ���������
    }

    private void Update()
    {
        pos.x = player.position.x;
        transform.position = Vector3.Lerp(transform.position, pos, 3 * Time.deltaTime); //Lerp �������� �� �������� ������. ��������� � deltaTime ������ �������� �������� ������
    }
}
