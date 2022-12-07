using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;

    [SerializeField]
    float _speed = 6f; // �̵��ӵ�


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        animator = gameObject.GetComponent<Animator>();

        Manager.Input.moveInputAction += UpdateMovement; // MoveInput���� �븮�ڿ� �̵��� �����ϴ� �Լ� �߰�
    }

    void Update()
    {
        if (animator.GetBool("Running")) // ���� �� �����ӿ� �ٰ��־����� Ȯ��
        {
            CheckMovement(); // �ٰ� �־��ٸ� ���� �����ӿ����� �ٰ��ִ��� Ȯ��
        }
    }

    void LateUpdate()
    {
        _lastPosition = transform.position; // ���� �����ӿ����� ������Ʈ ��ǥ�� ���� �����ӿ����� ������ ���� ����
    }


    Vector3 _lastPosition = Vector3.zero; // �� �����ӿ����� ��ǥ
    void CheckMovement() // �����̴��� Ȯ��, �������� ������ �ִϸ��̼� "Running" �Ķ���� ����
    {
        Vector3 moveDistance = _lastPosition - transform.position; // �� �����Ӱ� ���� �����Ӱ��� �Ÿ����� ���
        if (moveDistance.magnitude < 0.0001f) // �������� Ȯ�ε��� �ʴ´ٸ� "Running" �Ķ���� ��Ȱ��ȭ
        {
            animator.SetBool("Running", false);
        }
    }

    void UpdateMovement(float xMove, float zMove) // MoveInput ������ ȭ������ �̵��� ����
    {
        Vector3 getVel = new Vector3(xMove, 0, zMove) * _speed;

        if ((xMove == 0) || (zMove == 0))
        {
            getVel *= 1.414f;
        }
        rb.AddForce(getVel);

        animator.SetBool("Running", true); // �ִϸ��̼� �Ķ������ �̵� ������ ����
    }
}
