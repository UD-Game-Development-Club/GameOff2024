using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private Transform interactor;
    private readonly float interactRange = 1;
    public float InteractRange => interactRange;

    void Update()
    {
        if (gameInput.GetItemInteraction())
        {
            HandleInteraction();
        }
    }

    private void HandleInteraction()
    {
        Ray ray = new Ray(interactor.position, interactor.forward);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, interactRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                interactObj.OnInteraction();
            }
        }
    }
}
