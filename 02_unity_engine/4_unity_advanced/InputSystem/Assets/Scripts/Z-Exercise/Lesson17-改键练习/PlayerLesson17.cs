using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLesson17 : MonoBehaviour
{
    private PlayerInput _playerInput;
    
    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerInput.actions = DataManager.Instance.GetActionAsset();
        _playerInput.actions.Enable();
        _playerInput.onActionTriggered += OnActionTriggered;
    }

    private void OnActionTriggered(InputAction.CallbackContext obj)
    {
        if (obj.phase == InputActionPhase.Performed)
        {
            switch (obj.action.name)
            {
                case "Fire":
                    Debug.Log("Fire");
                    break;
                case "Jump":
                    Debug.Log("Jump");
                    break;
                case "Move":
                    Debug.Log("Move");
                    break;
            }
        }
    }

    public void ChangeInput()
    {
        _playerInput.actions = DataManager.Instance.GetActionAsset();
        _playerInput.actions.Enable();
    }
}
