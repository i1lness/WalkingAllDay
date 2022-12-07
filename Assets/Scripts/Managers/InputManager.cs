using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class InputManager
{
    public Action<float, float> moveInputAction = null; // Input���� �Ѱ��־� ��꿡 ����ϰ� ��

    public Action mouseInputAction = null;

    /* Input Ȯ���ϴ� �Լ� */
    public void CheckInput()
    {
        if (Input.anyKey)
        {
            float xMove = Input.GetAxis("Horizontal");
            float zMove = Input.GetAxis("Vertical");

            if ((xMove != 0) || (zMove != 0)) // MoveInput�� �����ϴ� ���
            {
                moveInputAction.Invoke(xMove, zMove);
            }
        }
    }
}
