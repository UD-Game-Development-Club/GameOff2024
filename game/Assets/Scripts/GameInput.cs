using UnityEngine;

public class GameInput : MonoBehaviour
{
    private InputSystem_Actions inputSystemActions;

    private void Awake()
    {
        inputSystemActions = new InputSystem_Actions();
        inputSystemActions.Player.Enable();
    }

    private void OnDestroy()
    {
        inputSystemActions.Player.Disable();
    }

    public Vector2 GetMovementVector2Normalized()
    {
        Vector2 inputVector2 = inputSystemActions.Player.Move.ReadValue<Vector2>();
        return inputVector2.normalized;
    }

    public bool GetInteractClick()
    {
        return inputSystemActions.Player.Interact.WasPressedThisFrame();
    }

    public Vector2 GetMouseDelta()
    {
        return inputSystemActions.Player.Look.ReadValue<Vector2>();
    }
    public bool GetAttackClick()
    {
        return inputSystemActions.Player.Attack.WasPressedThisFrame();
    }

    public void DisableMoveInput()
    {
        inputSystemActions.Player.Move.Disable();
    }

    public void EnableMoveInput()
    {
        inputSystemActions.Player.Move.Enable();
    }

    public void DisableLook()
    {
        inputSystemActions.Player.Look.Disable();
    }

    public void EnableLook()
    {
        inputSystemActions.Player.Look.Enable();
    }
    public bool GetItemInteraction()
    {
        return inputSystemActions.Player.ItemInteraction.WasPressedThisFrame();
    }

    public bool GetSpaceBar()
    {
        return inputSystemActions.Player.Jump.WasPressedThisFrame();
    }

    public bool GetDropItem()
    {
        return inputSystemActions.Player.DropItem.WasPressedThisFrame();
    }

    public bool GetLeftClick()
    {
        return inputSystemActions.Player.Attack.WasPressedThisFrame();
    }

    public bool GetMoveEnabled()
    {
        return inputSystemActions.Player.Move.enabled;
    }

    public bool GetLookEnabled()
    {
        return inputSystemActions.Player.Look.enabled;
    }
}