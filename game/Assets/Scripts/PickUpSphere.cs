using UnityEngine;

public class PickUpSphere : MonoBehaviour, IInteractable
{
    private PickUpController pickUpController;

    private void Start()
    {
        pickUpController = Camera.main.GetComponent<PickUpController>();
    }

    public void Interact()
    {
        if (pickUpController != null)
        {
            pickUpController.PickUpObject(gameObject);
        }
    }
}
