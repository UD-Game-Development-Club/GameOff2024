using UnityEngine;

public class Outliner : MonoBehaviour
{
    [SerializeField] private Interactor interactor;
    private Transform highlightedObject;

    void Update()
    {
        if (highlightedObject != null)
        {
            DisableOutline(highlightedObject);
            highlightedObject = null;
        }

        // debug: visualize ray
        // BUG: ray comes from the players feet, not the camera (with angle) - TODO
        // Debug.DrawRay(interactor.transform.position, interactor.transform.forward * interactor.InteractRange, Color.red);

        Ray ray = new Ray(interactor.transform.position, interactor.transform.forward);
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