using UnityEngine;

public class PickUpController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform originalParent;
    [SerializeField] private Transform holdPosition;
    private float throwForce = 400;
    [SerializeField] private GameInput gameInput;
    private GameObject heldObj;
    private Rigidbody heldObjRb;

    private void Start()
    {
        gameInput = gameObject.AddComponent<GameInput>();
    }

    private void Update()
    {
        if (heldObj != null)
        {
            MoveObject();
            if (gameInput.GetDropItem() || gameInput.GetInteractClick())
            {
                StopClipping();
                DropObject();
            }
            else if (gameInput.GetLeftClick())
            {
                StopClipping();
                ThrowObject();
            }
        }
    }

    public void PickUpObject(GameObject pickUpObj)
    {
        if (pickUpObj.GetComponent<Rigidbody>() && heldObj == null)
        {
            originalParent = heldObjRb.transform.parent;
            heldObj = pickUpObj;
            heldObjRb = pickUpObj.GetComponent<Rigidbody>();
            heldObjRb.isKinematic = true;
            heldObjRb.transform.parent = holdPosition.transform;
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        }
    }

    private void DropObject()
    {
        heldObjRb.transform.parent = originalParent.transform.parent;
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null;
        heldObj = null;
    }

    private void MoveObject()
    {
        heldObj.transform.position = holdPosition.transform.position;
    }

    private void ThrowObject()
    {
        heldObjRb.transform.parent = originalParent.transform.parent;
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null;
        heldObjRb.AddForce(transform.forward * throwForce);
        heldObj = null;
    }

    private void StopClipping()
    {
        var clipRange = Vector3.Distance(heldObj.transform.position, transform.position);
        RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.TransformDirection(Vector3.forward), clipRange);
        if (hits.Length > 1)
        {
            heldObj.transform.position = transform.position + new Vector3(0f, -0.5f, 0f);
        }
    }
}