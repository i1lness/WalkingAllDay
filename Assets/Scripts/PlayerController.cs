using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;

    [SerializeField]
    float _speed = 8f; // 오브젝트 이동속도


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        animator = gameObject.GetComponent<Animator>();

        Manager.Input.moveInputAction += UpdateMovement;
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


    Vector3 _lastPosition = Vector3.zero;
    void CheckMovement() // 움직이는지 확인, 움직이지 않으면 애니메이션 "Running" 파라미터 수정
    {
        Vector3 moveDistance = _lastPosition - transform.position;
        if (moveDistance.magnitude < 0.0001f) // 전 프레임과 위치가 같을 경우
        {
            animator.SetBool("Running", false);
        }
    }

    void UpdateMovement(float xMove, float zMove) // MoveInput값 받으면 화면으로 이동을 구현
    {
        Vector3 getVel = new Vector3(xMove, 0, zMove) * _speed;

        if ((xMove != 0) && (zMove != 0)) // 대각선 이동 시 빨라지는 현상 수정
        {
            getVel *= 0.7f;
        }
        rb.AddForce(getVel);

        animator.SetBool("Running", true);
    }
}
