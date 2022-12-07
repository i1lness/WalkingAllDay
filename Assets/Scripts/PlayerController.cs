using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;

    [SerializeField]
    float _speed = 8f; // ������Ʈ �̵��ӵ�


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        animator = gameObject.GetComponent<Animator>();

        Manager.Input.moveInputAction += UpdateMovement;
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


    Vector3 _lastPosition = Vector3.zero;
    void CheckMovement() // �����̴��� Ȯ��, �������� ������ �ִϸ��̼� "Running" �Ķ���� ����
    {
        Vector3 moveDistance = _lastPosition - transform.position;
        if (moveDistance.magnitude < 0.0001f) // �� �����Ӱ� ��ġ�� ���� ���
        {
            animator.SetBool("Running", false);
        }
    }

    void UpdateMovement(float xMove, float zMove) // MoveInput�� ������ ȭ������ �̵��� ����
    {
        Vector3 getVel = new Vector3(xMove, 0, zMove) * _speed;

        if ((xMove != 0) && (zMove != 0)) // �밢�� �̵� �� �������� ���� ����
        {
            getVel *= 0.7f;
        }
        rb.AddForce(getVel);

        animator.SetBool("Running", true);
    }
}
