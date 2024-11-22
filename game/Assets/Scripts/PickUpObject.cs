using UnityEngine;

public class PickUpObject : MonoBehaviour, IInteractable
{
    private PickUpController pickUpController;

    private void Start()
    {
        pickUpController = Camera.main.GetComponent<PickUpController>();
    }

    public void OnInteraction()
    {
        if (pickUpController != null)
        {
            pickUpController.PickUpObject(gameObject);
        }
    }
}