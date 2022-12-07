using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class InputManager
{
    public Action<float, float> moveInputAction = null; // MoveInput 관련 함수 대리자

    public Action mouseInputAction = null; // MouseInput 관련 함수 대리자

    public void OnUpdate() // InputManager가 매 프레임마다 확인해야 할 것을 모아놓은 함수
    {
        if (Input.anyKey) // 입력 받으면 실행
        {
            float xMove = Input.GetAxis("Horizontal"); // 오른쪽, 왼쪽의 MoveInput 확인 및 저장
            float zMove = Input.GetAxis("Vertical"); // 위, 아래의 MoveInput 확인 및 저장

            if ((xMove != 0) || (zMove != 0)) // 둘 중 하나라도 입력이 확인 된다면 실행
            {
                moveInputAction.Invoke(xMove, zMove); // 이동관련 함수 입력값과 함께 호출
            }
        }
    }
}
