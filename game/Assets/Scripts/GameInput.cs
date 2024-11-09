using UnityEngine;

public class GameInput : MonoBehaviour
{
    private InputSystem_Actions inputSystemActions;

    private void Awake()
    {
        inputSystemActions = new InputSystem_Actions();
        inputSystemActions.Player.Enable();
    }

    public Vector2 GetMovementVector2Normalized()
    {
        Vector2 inputVector2 = inputSystemActions.Player.Move.ReadValue<Vector2>();
        return inputVector2.normalized;
    }

    public Vector2 GetMouseDelta()
    {
        return inputSystemActions.Player.Look.ReadValue<Vector2>();
    }
}