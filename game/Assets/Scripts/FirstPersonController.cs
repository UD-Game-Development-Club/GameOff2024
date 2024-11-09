using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    private Camera playerCamera;
    private float sensitivityX = .1f;
    private float sensitivityY = .1f;

    private float rotationX = 0f;
    private float rotationY = 0f;

    [SerializeField] private Transform orientation;
    [SerializeField] private GameInput gameInput;

    private void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector2 mouseMovement = gameInput.GetMouseDelta();

        rotationY += mouseMovement.x * sensitivityX;
        rotationX -= mouseMovement.y * sensitivityY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        playerCamera.transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        orientation.rotation = Quaternion.Euler(0, rotationY, 0);
    }
}