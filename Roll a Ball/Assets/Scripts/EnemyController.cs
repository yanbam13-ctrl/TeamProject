using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Transform playerTr;
    public float speed;

    private void Update()
    {
        //오브젝트의 정면 방향이 있는 경우 플레이어를 바라본후 이동
        transform.LookAt(playerTr.position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        /*
        //방법 1
        Vector3 direction = playerTr.position - transform.position; // 움직일 방향
        direction.Normalize(); //vector의 길이가 커질때 이동 거리에 대한 문제를 해결 하기 위해 정규화 시킴
                               //direction = direction.normalized; [같은 코드임]

        transform.position += direction * speed * Time.deltaTime; // 이제 enemy를 이동 시키기
        */

    }

}
