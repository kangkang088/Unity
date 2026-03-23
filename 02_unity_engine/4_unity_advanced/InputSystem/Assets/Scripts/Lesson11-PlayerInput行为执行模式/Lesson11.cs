using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lesson11 : MonoBehaviour
{
    public void OnDeviceLost(PlayerInput input)
    {
        Debug.Log("设备丢失");
    }

    public void OnDeviceRegained(PlayerInput input)
    {
        Debug.Log("设备注册");
    }

    public void OnControlsChanged(PlayerInput input)
    {
        Debug.Log("设备改变");
    }

    #region Send Message / Broadcast

    public void OnMove(InputValue value)
    {
        Debug.Log("Move");

        Debug.Log(value.Get<Vector2>());
    }

    public void OnLook(InputValue value)
    {
        Debug.Log("Look");
    }

    public void OnFire(InputValue value)
    {
        Debug.Log("Fire");

        Debug.Log(value.isPressed);
    }

    #endregion

    #region Invoke Unity Events

    public void MyFire(InputAction.CallbackContext context)
    {
        Debug.Log("Fire");
    }

    public void MyLook(InputAction.CallbackContext context)
    {
        Debug.Log("Look");
    }

    public void MyMove(InputAction.CallbackContext context)
    {
        Debug.Log("Move");
    }

    #endregion

    #region Invoke CSharp Events

    private PlayerInput playerInput;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInput.onDeviceLost += OnDeviceLost;
        playerInput.onDeviceRegained += OnDeviceRegained;
        playerInput.onControlsChanged += OnControlsChanged;

        playerInput.onActionTriggered += OnActionTriggered;

        var value = playerInput.currentActionMap["Move"].ReadValue<Vector2>();
    }

    private void OnActionTriggered(InputAction.CallbackContext context)
    {
        Debug.Log("CS:" + context.action.name);
        Debug.Log("CS:" + context.control.name);

        if (context.action.name == "Move" || context.action.name == "Look")
        {
            Debug.Log(context.ReadValue<Vector2>());
        }
    }

    #endregion
}
