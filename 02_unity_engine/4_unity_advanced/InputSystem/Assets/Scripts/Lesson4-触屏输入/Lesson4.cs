using UnityEngine;
using UnityEngine.InputSystem;

public class Lesson4 : MonoBehaviour
{
    private Touchscreen touchscreen;// 一般在移动平台使用

    private void Start()
    {
        touchscreen = Touchscreen.current;

        if (touchscreen == null)
        {
            Debug.Log("当前设备没有触屏！");
            return;
        }

    }

    private void Update()
    {
        Debug.Log($"当前触屏上有{touchscreen.touches.Count}个触点！");

        // 拿到第一个触点（手指）
        var touch = touchscreen.touches[0];

        if (touch.press.wasPressedThisFrame)
        {
            Debug.Log("触点被按下了！");
        }

        if (touch.press.wasReleasedThisFrame)
        {
            Debug.Log("触点被松开了！");
        }

        if (touch.press.isPressed)
        {
            Debug.Log("触点正在被按下！");
        }

        if (touch.position.ReadValue().x > Screen.width / 2)
        {
            Debug.Log("触点在屏幕右半边！");
        }
        else
        {
            Debug.Log("触点在屏幕左半边！");
        }

        Debug.Log($"触点被轻触了 {touch.tapCount.ReadValue()} 次！");

        if (touch.tap.wasPressedThisFrame)
        {
            Debug.Log("触点被轻触了一次！");
        }

        if (touch.tap.wasReleasedThisFrame)
        {
            Debug.Log("触点轻触被松开了！");
        }

        if (touch.tap.isPressed)
        {
            Debug.Log("触点正在被轻触！");
        }

        Debug.Log(touch.startPosition.ReadValue());// 触点开始接触屏幕时的位置
        Debug.Log(touch.position.ReadValue());// 触点在屏幕上的位置
        Debug.Log(touch.radius.ReadValue());// 触点的半径，表示触点的大小
        Debug.Log(touch.delta.ReadValue());// 触点位置的变化量
        Debug.Log(touch.pressure.ReadValue());// 触点的压力，通常在使用Apple Pencil等压感设备时有用
        Debug.Log(touch.phase.ReadValue());// 触点的状态：按下、移动、松开等

        switch (touch.phase.ReadValue())
        {
            case UnityEngine.InputSystem.TouchPhase.Began:
                Debug.Log("触点开始接触屏幕了！");
                break;
            case UnityEngine.InputSystem.TouchPhase.Moved:
                Debug.Log("触点在屏幕上移动了！");
                break;
            case UnityEngine.InputSystem.TouchPhase.Stationary:
                Debug.Log("触点在屏幕上保持不动了！");
                break;
            case UnityEngine.InputSystem.TouchPhase.Ended:
                Debug.Log("触点松开了！");
                break;
            case UnityEngine.InputSystem.TouchPhase.Canceled:
                Debug.Log("触点被系统取消了！");
                break;
        }
    }
}
