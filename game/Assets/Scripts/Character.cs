using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private Transform orientation;
    private float moveSpeed = 6;

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, orientation.eulerAngles.y, 0);

        Vector2 inputVector = gameInput.GetMovementVector2Normalized();
        Vector3 moveDirection = orientation.forward * inputVector.y + orientation.right * inputVector.x;
        moveDirection.y = 0;

        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}