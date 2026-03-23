using UnityEngine;
using UnityEngine.InputSystem;

public class Lesson12 : MonoBehaviour
{
    private Vector3 dir;

    private void Start()
    {
        PlayerInputManager.instance.onPlayerJoined += OnPlayerJoined;
        PlayerInputManager.instance.onPlayerLeft += OnPlayerLeft;
    }

    private void OnPlayerLeft(PlayerInput input)
    {
        Debug.Log("One Player Left");
    }

    private void OnPlayerJoined(PlayerInput input)
    {
        Debug.Log("One Player Joined");
    }

    private void Update()
    {
        transform.Translate(10 * Time.deltaTime * dir);
    }

    public void Move(InputAction.CallbackContext context)
    {
        dir = context.ReadValue<Vector2>();
        dir.z = dir.y;
        dir.y = 0;
    }
}
