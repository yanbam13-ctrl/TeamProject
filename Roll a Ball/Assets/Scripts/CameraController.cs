using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.transform.position; // offset = 카메라의 위치 - 플레이어의 위치
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + offset; // 카메라의 위치는 플레이어의 위치 + offset
    }
}
