using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;

    [SerializeField]
    float _speed = 6f; // 이동속도


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        animator = gameObject.GetComponent<Animator>();

        Manager.Input.moveInputAction += UpdateMovement; // MoveInput관련 대리자에 이동을 구현하는 함수 추가
    }

    void Update()
    {
        if (animator.GetBool("Running")) // 만약 전 프레임에 뛰고있었는지 확인
        {
            CheckMovement(); // 뛰고 있었다면 현재 프레임에서도 뛰고있는지 확인
        }
    }

    void LateUpdate()
    {
        _lastPosition = transform.position; // 현재 프레임에서의 오브젝트 좌표를 다음 프레임에서의 연산을 위해 저장
    }


    Vector3 _lastPosition = Vector3.zero; // 전 프레임에서의 좌표
    void CheckMovement() // 움직이는지 확인, 움직이지 않으면 애니메이션 "Running" 파라미터 수정
    {
        Vector3 moveDistance = _lastPosition - transform.position; // 전 프레임과 현재 프레임간의 거리차이 계산
        if (moveDistance.magnitude < 0.0001f) // 움직임이 확인되지 않는다면 "Running" 파라미터 비활성화
        {
            animator.SetBool("Running", false);
        }
    }

    void UpdateMovement(float xMove, float zMove) // MoveInput 받으면 화면으로 이동을 구현
    {
        Vector3 getVel = new Vector3(xMove, 0, zMove) * _speed;

        if ((xMove == 0) || (zMove == 0))
        {
            getVel *= 1.414f;
        }
        rb.AddForce(getVel);

        animator.SetBool("Running", true); // 애니메이션 파라미터을 이동 중으로 수정
    }
}
