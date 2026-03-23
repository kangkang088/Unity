using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Lesson16 : MonoBehaviour
{
    public PlayerInput _playerInput;
    
    private void Start()
    {
        var jsonStr = Resources.Load<TextAsset>("PlayerInputTest").text;
        var inputActionAsset = InputActionAsset.FromJson(jsonStr);
        _playerInput.actions = inputActionAsset;
        
        _playerInput.onActionTriggered += OnActionTriggered;
    }

    private void OnActionTriggered(InputAction.CallbackContext obj)
    {
        if (obj.action.name == "Move" && obj.phase == InputActionPhase.Performed)
        {
            Debug.Log("Move");
        }
    }
}
