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

        //movement.magnitude : movement 벡터의 크기
        //movement.normalized : movement 벡터의 정규화 -> 변수 원본이(movement 벡터의 변화 x) 바뀌지 않음
        //movement.Normalize() : movement 벡터의 정규화 -> 메서드 원본(movement 벡터의 변화 o)이 바뀜
        //Vector3.up = new Vector3(0,1,0)
        //Vector3.zero = new Vector3(0, 0, 0)
        //Vector3.one = new Vector3(1, 1, 1)

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")) //tag 비교
        {
            PickUpController pc = other.GetComponent<PickUpController>();
            Debug.Log("pcScore : " +pc.score);
            score += pc.score;
            other.gameObject.SetActive(false);// 이 오브젝트의 활성화 여부를 false (게임에서 보이지 않도록 체크해제)
            count++;
            SetCountText();

           

        }

        //else if (other.gameObject.CompareTag("Capsule")) //tag 비교
        //{
        //    other.gameObject.SetActive(false);// 이 오브젝트의 활성화 여부를 false (게임에서 보이지 않도록 체크해제)
        //    bonus++;
        //    SetCountText();
        //}
        //else
        //{
        //    other.gameObject.SetActive(false);// 이 오브젝트의 활성화 여부를 false (게임에서 보이지 않도록 체크해제)
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
