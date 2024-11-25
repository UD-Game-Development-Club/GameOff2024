using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private TimeTravel timeTravel;

    [SerializeField] private float moveSpeed;

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
         * Movement
         */
        Vector2 inputVector = gameInput.GetMovementVector2Normalized();
        Vector3 moveDirection = (transform.forward * inputVector.y) + (transform.right * inputVector.x);
        moveDirection.y = 0;

        bool isMoving = moveDirection.magnitude > 0.1f;

        // Preserve the y-axis (gravity) component while manually setting horizontal movement
        Vector3 newVelocity = moveDirection * moveSpeed;
        newVelocity.y = rb.linearVelocity.y;
        rb.linearVelocity = newVelocity;

        /*
         * Footstep sounds
         */
        if (isMoving)
        {
            // additional check here to save the overhead of a raycast (probably negligible)
            if (footstepController.footstepCooldown <= 0)
            {
                // DEBUG
                // Vector3 rayOrigin = transform.position;
                // Vector3 rayDirection = Vector3.down;
                // float rayDistance = 10f; // Adjust this to match your ray length
                // Debug.DrawRay(rayOrigin, rayDirection * rayDistance, Color.red, 0.1f);

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
}
