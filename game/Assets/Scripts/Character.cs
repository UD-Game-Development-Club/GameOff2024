using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private TimeTravel timeTravel;
    [SerializeField] private float moveSpeed = 7;
    private float rotateSpeed = 10;

    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVector2Normalized();

        Vector3 moveDirection = new Vector3(inputVector.x, 0, inputVector.y);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);

        if(gameInput.GetInteractClick())
        {
            timeTravel.SwitchTimePeriod();
        }
    }

}
