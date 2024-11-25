using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private TimeTravel timeTravel;

    private float moveSpeed;
    private float groundCheckDistance = 1.0f; // Distance to check for ground

    private FootstepController footstepController;

    private Rigidbody rb;

    // this Layer denotes surfaces we can walk on,
    // specifically with tags specifying the material
    public LayerMask groundLayer;

    private Camera playerCamera;
    private float sensitivityX = .1f;
    private float sensitivityY = .1f;

    private float rotationX = 0f;
    private float rotationY = 0f;

    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        footstepController = GetComponent<FootstepController>();

        playerCamera = GetComponentInChildren<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        /*
         * Check if grounded by casting a ray downwards
         */
        isGrounded = CheckGrounded();

        /*
         * Movement
         */
        Vector2 inputVector = gameInput.GetMovementVector2Normalized();
        Vector3 moveDirection = (transform.forward * inputVector.y) + (transform.right * inputVector.x);
        moveDirection.y = 0; // Ensure no vertical movement in horizontal plane

        bool isMoving = moveDirection.magnitude > 0.1f;

        // Preserve the y-axis (gravity) component while manually setting horizontal movement
        Vector3 newVelocity = moveDirection * moveSpeed;

        if (isGrounded)
        {
            // When grounded, set vertical velocity to 0 to avoid floating
            newVelocity.y = rb.linearVelocity.y;
        }
        else
        {
            // Apply gravity if not grounded
            newVelocity.y = rb.linearVelocity.y; // Allow gravity to take effect
        }

        rb.linearVelocity = newVelocity;

        /*
         * Footstep sounds
         */
        if (isMoving)
        {
            if (footstepController.footstepCooldown <= 0)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, Vector3.down, out hit, groundLayer))
                {
                    footstepController.PlayFootstepSound(hit);
                }
            }
        }

        /*
         * Camera
         */
        Vector2 mouseMovement = gameInput.GetMouseDelta();
        rotationY += mouseMovement.x * sensitivityX;
        rotationX -= mouseMovement.y * sensitivityY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.rotation = Quaternion.Euler(0, rotationY, 0);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }

    private bool CheckGrounded()
{
    Vector3 rayOrigin = transform.position + Vector3.up * 0.1f;
    RaycastHit hit;

    // Debug: Draw the ray
    //Debug.DrawRay(rayOrigin, Vector3.down * groundCheckDistance, Color.red, 0.1f);

    if (Physics.Raycast(rayOrigin, Vector3.down, out hit, groundCheckDistance, groundLayer))
    {
        //Debug.DrawRay(rayOrigin, Vector3.down * hit.distance, Color.blue, 0.1f);
        gameInput.EnableMoveInput();
        return true;
    }

    gameInput.DisableMoveInput();
    return false;
}

}
