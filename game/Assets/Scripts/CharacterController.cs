using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private TimeTravel timeTravel;

    [SerializeField] private float moveSpeed;

    private Rigidbody rb;

    private Camera playerCamera;
    private float sensitivityX = .1f;
    private float sensitivityY = .1f;

    private float rotationX = 0f;
    private float rotationY = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        playerCamera = GetComponentInChildren<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        /*
         * Movement
         */
        Vector2 inputVector = gameInput.GetMovementVector2Normalized();
        Vector3 moveDirection = (transform.forward * inputVector.y) + (transform.right * inputVector.x);
        moveDirection.y = 0;

        // Preserve the y-axis (gravity) component while manually setting horizontal movement
        Vector3 newVelocity = moveDirection * moveSpeed;
        newVelocity.y = rb.linearVelocity.y;
        rb.linearVelocity = newVelocity;

        /*
         * Camera
         */
        Vector2 mouseMovement = gameInput.GetMouseDelta();
        rotationY += mouseMovement.x * sensitivityX;
        rotationX -= mouseMovement.y * sensitivityY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.rotation = Quaternion.Euler(0, rotationY, 0);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        /*
         * Time Travel
         */
        if (gameInput.GetInteractClick())
        {
            timeTravel.SwitchTimePeriod();
        }
    }
}
