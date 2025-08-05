using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb2d;
    private int count;
    public TMP_Text countText;
    public TMP_Text winText;
    private int PickupCnt;
    public TMP_Text gameover;
    private int Point;
    public TMP_Text PointText;

    public BoxCollider2D eastWall;
    public BoxCollider2D westWall;
    public BoxCollider2D southWall;
    public BoxCollider2D northWall;


    private void Start()
    {
        GameObject[] pickups = GameObject.FindGameObjectsWithTag("Pickup");
        PickupCnt = pickups.Length;
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        Point = 0;
        
        SetCountText();
        winText.text=" ";
        SetPointText();
        gameover.text=" ";

    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed); //Time.deltaTime 이건 update에서 만 사용 가능
                                        //Time.fixedDeltaTime 이건 FixedUpdate 여기서만 !!!
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pickup"))
        {
            Destroy(collision.gameObject);
            count++;
            SetCountText();
            Point += 10;
            SetPointText();
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BackGround"))
        {
            Point -= 5;
            SetPointText();
        }
    }

    void SetPointText()
    {
        PointText.text = "Point : " + Point.ToString();
        if (Point < 0)
        {
            PointText.text = "Score : 0";
            gameover.text = "Game Over!";
            Time.timeScale = 0;
        }
    }

    void SetCountText()
    {
        countText.text = "Count : " + count.ToString();
       
        if(count >= PickupCnt)
        {
            winText.text = "You win!";
        }
    }
   
}
