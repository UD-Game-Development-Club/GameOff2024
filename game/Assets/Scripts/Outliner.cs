using UnityEngine;

public class Outliner : MonoBehaviour
{
    [SerializeField] private Interactor interactor;
    [SerializeField] private Camera playerCamera;
    private Transform highlightedObject;

    void Update()
    {
        if (highlightedObject != null)
        {
            DisableOutline(highlightedObject);
            highlightedObject = null;
        }

        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        // Interactor Range - Debug visualization
        Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * interactor.InteractRange, Color.red);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, interactor.InteractRange))
        {
            Transform target = hitInfo.transform;
            if (target.CompareTag("Selectable"))
            {
                EnableOutline(target);
                highlightedObject = target;
            }
        }
    }

    private void EnableOutline(Transform target)
    {
        Outline outline = target.GetComponent<Outline>();
        if (outline == null) outline = target.gameObject.AddComponent<Outline>();
        outline.enabled = true;
    }

    private void DisableOutline(Transform target)
    {
        Outline outline = target.GetComponent<Outline>();
        if (outline != null) outline.enabled = false;
    }
}