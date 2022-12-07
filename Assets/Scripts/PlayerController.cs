using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;

    [SerializeField]
    float _speed = 6f;

    public static bool isRunning = false;

    Vector3 _lastPosition = Vector3.zero;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        animator = gameObject.GetComponent<Animator>();

        Manager.Input.moveInputAction += UpdateMovement;
    }

    void Update()
    {
        if (isRunning)
        {
            CheckMovement();
        }
    }

    void LateUpdate()
    {
        _lastPosition = transform.position;
    }

    void CheckMovement()
    {
        Vector3 moveDistance = _lastPosition - transform.position;
        if (moveDistance.magnitude < 0.0001f)
        {
            animator.SetBool("Running", false);
            isRunning = false;
        }
    }

    void UpdateMovement(float xMove, float zMove)
    {
        Vector3 getVel = new Vector3(xMove, 0, zMove) * _speed;

        if ((xMove == 0) || (zMove == 0))
        {
            getVel *= 1.414f;
        }
        rb.AddForce(getVel);

        animator.SetBool("Running", true);
        isRunning = true;
    }
}
