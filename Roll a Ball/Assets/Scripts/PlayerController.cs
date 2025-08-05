using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public Text scoreText;
    private Rigidbody rb;
    private int count;
    private int bonus;
    private int bigBonus;
    private int score;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        //movement.magnitude : movement ������ ũ��
        //movement.normalized : movement ������ ����ȭ -> ���� ������(movement ������ ��ȭ x) �ٲ��� ����
        //movement.Normalize() : movement ������ ����ȭ -> �޼��� ����(movement ������ ��ȭ o)�� �ٲ�
        //Vector3.up = new Vector3(0,1,0)
        //Vector3.zero = new Vector3(0, 0, 0)
        //Vector3.one = new Vector3(1, 1, 1)

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")) //tag ��
        {
            PickUpController pc = other.GetComponent<PickUpController>();
            Debug.Log("pcScore : " +pc.score);
            score += pc.score;
            other.gameObject.SetActive(false);// �� ������Ʈ�� Ȱ��ȭ ���θ� false (���ӿ��� ������ �ʵ��� üũ����)
            count++;
            SetCountText();

           

        }

        //else if (other.gameObject.CompareTag("Capsule")) //tag ��
        //{
        //    other.gameObject.SetActive(false);// �� ������Ʈ�� Ȱ��ȭ ���θ� false (���ӿ��� ������ �ʵ��� üũ����)
        //    bonus++;
        //    SetCountText();
        //}
        //else
        //{
        //    other.gameObject.SetActive(false);// �� ������Ʈ�� Ȱ��ȭ ���θ� false (���ӿ��� ������ �ʵ��� üũ����)
        //    bigBonus++;
        //    SetCountText();
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {
            winText.text = "Game Over!";
            Time.timeScale = 0;
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + (bonus + count + bigBonus).ToString();
        //scoreText.text = "Score : " + ((count * 10) + (bonus * 20) + (bigBonus * 30)).ToString();
        scoreText.text = "score : "+score;

        if (count >= 14)
        {
            winText.text = "You Win!";
        }

        //if ((count + bonus + bigBonus) >= 14)
        //{
        //    winText.text = "You Win!";
        //}
    }
}
