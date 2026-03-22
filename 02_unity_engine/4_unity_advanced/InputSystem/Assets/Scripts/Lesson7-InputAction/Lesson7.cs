using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lesson7 : MonoBehaviour
{
    public InputAction move;
    public InputAction fire;
    private void Start()
    {
        // InputAction类-对前面那些设备类的封装,可视化
        move.Enable();

        move.started += Started;
        move.performed += Performed;
        move.canceled += Canceled;
    }

    private void Canceled(InputAction.CallbackContext context)
    {
        Debug.Log("Canceled");

        if (context.phase == InputActionPhase.Canceled)
        {
            Debug.Log("Phase Canceled");
        }
    }

    private void Performed(InputAction.CallbackContext context)
    {
        Debug.Log("Performed");

        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("Phase Performed");
            // Debug.Log(context.performed);
            Debug.Log(context.duration);
        }
    }

    private void Started(InputAction.CallbackContext context)
    {
        Debug.Log("Started");

        if (context.phase == InputActionPhase.Started)
        {
            Debug.Log("Phase Started");

            // Debug.Log(context.action.name);

            // Debug.Log(context.control.name);

            // Debug.Log(context.ReadValue<float>());

            // Debug.Log(context.duration);

            // Debug.Log(context.startTime);
        }
    }
}
