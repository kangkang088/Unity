using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lesson2 : MonoBehaviour
{
    private Keyboard keyboard;

    private void Start()
    {
        keyboard = Keyboard.current;

        keyboard.onTextInput += OnTextInput;
    }

    private void OnTextInput(char obj)
    {
        if (obj == 'b')
            Debug.Log($"输入了字符：{obj}");
    }

    private void Update()
    {
        if (keyboard.aKey.wasPressedThisFrame)
        {
            Debug.Log("A键被按下了！");
        }

        if (keyboard.aKey.wasReleasedThisFrame)
        {
            Debug.Log("A键被松开了！");
        }

        if (keyboard.aKey.isPressed)
        {
            Debug.Log("A键正在被按下！");
        }

        if (keyboard.anyKey.wasPressedThisFrame)
        {
            Debug.Log("任意键被按下了！");
        }

        if (keyboard.anyKey.wasReleasedThisFrame)
        {
            Debug.Log("任意键被松开了！");
        }

        if (keyboard.anyKey.isPressed)
        {
            Debug.Log("任意键正在被按下！");
        }

    }
}
