using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson9 : MonoBehaviour
{
    private Lesson9Input inputActions;

    private void Start()
    {
        inputActions = new();

        inputActions.Enable();

        inputActions.Action1.Fire.performed += context => Debug.Log("Fire");

        inputActions.Action2.Jump.performed += context => Debug.Log("Jump");
    }

    private void Update()
    {
        Debug.Log(inputActions.Action1.Move.ReadValue<Vector2>());
    }
}
