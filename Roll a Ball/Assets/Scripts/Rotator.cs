using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    private Vector3 rotationAxis; // ȸ�� ����
    private float rotationSpeed;  // ȸ�� �ӵ�

    private void Start()
    {
        // ���� ȸ�� ���� (����ȭ�� ���ͷ� ���⸸ ������)
        rotationAxis = Random.insideUnitSphere;

        // ���� �ӵ� (��: 20�� ~ 100�� ����)
        rotationSpeed = Random.Range(20f, 100f);


        Debug.Log($"ȸ�� ����: {rotationAxis}, ȸ�� �ӵ�: {rotationSpeed}");
    }
    private void Update()
    {
        //ȸ�� ������ ���� ���� (���� �� ȸ�� �ӵ��� ��������)
        // �� ������ ȸ��
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);


        //transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

        // ���� ������ �ٸ� ����� �̵� �Ǵ� ȸ���� �ӵ��� ���߱� ���� Time.deltaTime�� �� ��� �ؾ���.
        // Time.DeltaTime�� ���ؼ� �̵� �ӵ��� ����
        // ������ ��ȭ���� Time.deltaTime ���̸�ŭ ������ �־��ش�.
        // ���������� �� �۵��Ǵ°� ó�� ������ ������ �ٸ���. �ſ� �߿�!
        // ��Ȳ�� ���� �޶����µ� *** ����Ű�� �ѹ� �������� 1��ŭ �̵��ϴ� ����� ���� Time.deltaTime�� ����ؾ� �ϴ°�?.......... �̷����� ��� ���� �ʾƵ� �ȴ�.



    }
}
