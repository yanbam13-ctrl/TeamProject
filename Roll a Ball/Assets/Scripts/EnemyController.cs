using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Transform playerTr;
    public float speed;

    private void Update()
    {
        //������Ʈ�� ���� ������ �ִ� ��� �÷��̾ �ٶ��� �̵�
        transform.LookAt(playerTr.position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        /*
        //��� 1
        Vector3 direction = playerTr.position - transform.position; // ������ ����
        direction.Normalize(); //vector�� ���̰� Ŀ���� �̵� �Ÿ��� ���� ������ �ذ� �ϱ� ���� ����ȭ ��Ŵ
                               //direction = direction.normalized; [���� �ڵ���]

        transform.position += direction * speed * Time.deltaTime; // ���� enemy�� �̵� ��Ű��
        */

    }

}
