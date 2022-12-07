using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class InputManager
{
    public Action<float, float> moveInputAction = null; // Input값을 넘겨주어 계산에 사용하게 함

    public Action mouseInputAction = null;

    /* Input 확인하는 함수 */
    public void CheckInput()
    {
        if (Input.anyKey)
        {
            float xMove = Input.GetAxis("Horizontal");
            float zMove = Input.GetAxis("Vertical");

            if ((xMove != 0) || (zMove != 0)) // MoveInput이 존재하는 경우
            {
                moveInputAction.Invoke(xMove, zMove);
            }
        }
    }
}
