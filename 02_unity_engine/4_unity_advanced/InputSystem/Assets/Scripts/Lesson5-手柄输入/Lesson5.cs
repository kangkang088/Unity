using UnityEngine;
using UnityEngine.InputSystem;

public class Lesson5 : MonoBehaviour
{
    private Gamepad gamepad;

    private void Start()
    {
        gamepad = Gamepad.current;
        if (gamepad == null)
        {
            Debug.LogError("No gamepad found!");
            return;
        }
    }

    private void Update()
    {
        // 摇杆
        Vector2 leftStick = gamepad.leftStick.ReadValue();

        if (gamepad.leftStickButton.wasPressedThisFrame)
        {
            Debug.Log("Left Stick Button Pressed");
        }

        if (gamepad.rightStickButton.wasPressedThisFrame)
        {
            Debug.Log("Right Stick Button Pressed");
        }

        if (gamepad.leftStickButton.isPressed)
        {
            Debug.Log("Left Stick Button is being held down");
        }

        // 方向键
        if (gamepad.dpad.up.wasPressedThisFrame)
        {
            Debug.Log("D-pad Up Pressed");
        }

        if (gamepad.dpad.down.wasReleasedThisFrame)
        {
            Debug.Log("D-pad Down Released");
        }

        if (gamepad.dpad.left.isPressed)
        {
            Debug.Log("D-pad Left is being held down");
        }

        if (gamepad.dpad.right.wasPressedThisFrame)
        {
            Debug.Log("D-pad Right Pressed");
        }

        // 手柄通用按钮 
        if (gamepad.buttonNorth.wasReleasedThisFrame)
        {
            Debug.Log("Button Top Button Released");
        }

        if (gamepad.buttonSouth.wasPressedThisFrame)
        {
            Debug.Log("Button Down Button Pressed");
        }

        if (gamepad.buttonWest.isPressed)
        {
            Debug.Log("Button Left is being held down");
        }

        if (gamepad.buttonEast.wasPressedThisFrame)
        {
            Debug.Log("Button Right Pressed");
        }

        // 下面的不建议用
        var triangleButton = gamepad.triangleButton;
        var spuareButotn = gamepad.squareButton;
        var crossButton = gamepad.crossButton;
        var circleButton = gamepad.circleButton;

        var aButton = gamepad.aButton;
        var bButotn = gamepad.bButton;
        var xButton = gamepad.xButton;
        var yButton = gamepad.yButton;

        //中央按钮
        if (gamepad.startButton.wasPressedThisFrame)
        {
            Debug.Log("开始键按下");
        }

        if (gamepad.selectButton.wasReleasedThisFrame)
        {
            Debug.Log("选择键松开");
        }

        //肩部按钮
        if (gamepad.leftShoulder.wasPressedThisFrame)
        {
            Debug.Log("左肩部前方键被按下");
        }

        if (gamepad.leftTrigger.wasReleasedThisFrame)
        {
            Debug.Log("左肩部后方键释放");
        }
    }
}
