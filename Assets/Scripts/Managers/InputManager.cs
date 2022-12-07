using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class InputManager
{
    public Action<float, float> moveInputAction = null; // MoveInput ���� �Լ� �븮��

    public Action mouseInputAction = null; // MouseInput ���� �Լ� �븮��

    public void OnUpdate() // InputManager�� �� �����Ӹ��� Ȯ���ؾ� �� ���� ��Ƴ��� �Լ�
    {
        if (Input.anyKey) // �Է� ������ ����
        {
            float xMove = Input.GetAxis("Horizontal"); // ������, ������ MoveInput Ȯ�� �� ����
            float zMove = Input.GetAxis("Vertical"); // ��, �Ʒ��� MoveInput Ȯ�� �� ����

            if ((xMove != 0) || (zMove != 0)) // �� �� �ϳ��� �Է��� Ȯ�� �ȴٸ� ����
            {
                moveInputAction.Invoke(xMove, zMove); // �̵����� �Լ� �Է°��� �Բ� ȣ��
            }
        }
    }
}
