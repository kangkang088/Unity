using UnityEngine;
using UnityEngine.InputSystem;

public class Lesson3 : MonoBehaviour
{
    private Mouse mouse;

    private void Start()
    {
        mouse = Mouse.current;
    }

    private void Update()
    {
        if (mouse.leftButton.wasPressedThisFrame)
        {
            Debug.Log("鼠标左键被按下了！");
        }

        if (mouse.leftButton.wasReleasedThisFrame)
        {
            Debug.Log("鼠标左键被松开了！");
        }

        if (mouse.leftButton.isPressed)
        {
            Debug.Log("鼠标左键正在被按下！");
        }

        if (mouse.rightButton.wasPressedThisFrame)
        {
            Debug.Log("鼠标右键被按下了！");
        }

        if (mouse.rightButton.wasReleasedThisFrame)
        {
            Debug.Log("鼠标右键被松开了！");
        }

        if (mouse.rightButton.isPressed)
        {
            Debug.Log("鼠标右键正在被按下！");
        }

        if (mouse.middleButton.wasPressedThisFrame)
        {
            Debug.Log("鼠标中键被按下了！");
        }

        if (mouse.middleButton.wasReleasedThisFrame)
        {
            Debug.Log("鼠标中键被松开了！");
        }

        if (mouse.middleButton.isPressed)
        {
            Debug.Log("鼠标中键正在被按下！");
        }

        if (mouse.scroll.ReadValue().y > 0)
        {
            Debug.Log("鼠标滚轮向上滚动了！");
        }

        if (mouse.scroll.ReadValue().y < 0)
        {
            Debug.Log("鼠标滚轮向下滚动了！");
        }

        if (mouse.position.ReadValue().x > Screen.width / 2)
        {
            Debug.Log("鼠标在屏幕右半部分！");
        }
        else
        {
            Debug.Log("鼠标在屏幕左半部分！");
        }

        if (mouse.forwardButton.wasPressedThisFrame)
        {
            Debug.Log("鼠标前进键被按下了！");
        }

        if (mouse.forwardButton.wasReleasedThisFrame)
        {
            Debug.Log("鼠标前进键被松开了！");
        }

        if (mouse.forwardButton.isPressed)
        {
            Debug.Log("鼠标前进键正在被按下！");
        }

        if (mouse.backButton.wasPressedThisFrame)
        {
            Debug.Log("鼠标后退键被按下了！");
        }

        if (mouse.backButton.wasReleasedThisFrame)
        {
            Debug.Log("鼠标后退键被松开了！");
        }

        if (mouse.backButton.isPressed)
        {
            Debug.Log("鼠标后退键正在被按下！");
        }

        var delta = mouse.delta.ReadValue();
        if (delta.x != 0 || delta.y != 0)
        {
            Debug.Log($"鼠标移动了！增量：{delta}");
        }
    }
}
