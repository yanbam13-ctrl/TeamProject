using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    private Vector3 rotationAxis; // 회전 방향
    private float rotationSpeed;  // 회전 속도

    private void Start()
    {
        // 랜덤 회전 방향 (정규화된 벡터로 방향만 정해줌)
        rotationAxis = Random.insideUnitSphere;

        // 랜덤 속도 (예: 20도 ~ 100도 사이)
        rotationSpeed = Random.Range(20f, 100f);


        Debug.Log($"회전 방향: {rotationAxis}, 회전 속도: {rotationSpeed}");
    }
    private void Update()
    {
        //회전 방향을 랜덤 적용 (적용 후 회전 속도도 랜덤적용)
        // 매 프레임 회전
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);


        //transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

        // 서로 성능이 다른 장비의 이동 또는 회전의 속도를 맞추기 위해 Time.deltaTime을 꼭 사용 해야함.
        // Time.DeltaTime을 곱해서 이동 속도를 조절
        // 스케일 변화에도 Time.deltaTime 차이만큼 보정을 넣어준다.
        // 정상적으로 잘 작동되는것 처럼 보여도 실제는 다르다. 매우 중요!
        // 상황에 따라 달라지는데 *** 방향키를 한번 눌렀을때 1만큼 이동하는 경우라면 과연 Time.deltaTime을 사용해야 하는가?.......... 이런경우는 사용 하지 않아도 된다.



    }
}
