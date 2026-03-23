using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class Lesson15 : MonoBehaviour
{
    public InputAction InputAction;
    
    private void Start()
    {
        // 不行得到具体键位信息
        // InputAction.Enable();
        // InputAction.performed += InputActionOnperformed;
        // 可以得到具体键位信息，但仅限于字符,键盘的键位得不全
        // Keyboard.current.onTextInput += CurrentOnonTextInput;
        
        // InputSystem提供的
        InputSystem.onAnyButtonPress.Call(inputControl =>
        {
            Debug.Log(inputControl.name);
            Debug.Log(inputControl.path);
        });
    }

    private void CurrentOnonTextInput(char obj)
    {
        Debug.Log(obj);
    }

    private void InputActionOnperformed(InputAction.CallbackContext obj)
    {
        Debug.Log(obj.control.name);// 只会打印anykey，获取不到具体的键位信息
    }
}
