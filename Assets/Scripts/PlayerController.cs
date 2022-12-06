using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    float _speed = 10f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");

        Vector3 getVel = new Vector3(xMove, 0, zMove) * _speed;

        if ((xMove == 0) || (zMove == 0))
        {
            getVel *= 1.414f;
        }
        rb.AddForce(getVel);
    }
}
