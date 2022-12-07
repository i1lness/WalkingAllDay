using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class InputManager
{
    public Action<float, float> moveInputAction = null;

    public Action mouseInputAction = null;

    public void OnUpdate()
    {
        if (Input.anyKey)
        {
            float xMove = Input.GetAxis("Horizontal");
            float zMove = Input.GetAxis("Vertical");

            if ((xMove != 0) || (zMove != 0))
            {
                PlayerController.isRunning = true;
                moveInputAction.Invoke(xMove, zMove);
            }
        }
    }
}
