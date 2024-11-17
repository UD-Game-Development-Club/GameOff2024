using UnityEngine;

// First, the PickUpController becomes more focused on just handling held objects
public class PickUpController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform holdPosition;
    [SerializeField] private float throwForce = 500f;
    [SerializeField] private float rotationSensitivity = 1f;

    private GameObject heldObj;
    private Rigidbody heldObjRb;
    private bool canDrop = true;
    private int holdLayerNumber;

    private void Start()
    {
        holdLayerNumber = LayerMask.NameToLayer("holdLayer");
    }

    private void Update()
    {
        if (heldObj != null)
        {
            MoveObject();
            RotateObject();

            // Drop or throw
            if (Input.GetKeyDown(KeyCode.E) && canDrop)
            {
                StopClipping();
                DropObject();
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && canDrop)
            {
                StopClipping();
                ThrowObject();
            }
        }
    }

    // Make this public so it can be called from PickUpSphere
    public void PickUpObject(GameObject pickUpObj)
    {
        if (pickUpObj.GetComponent<Rigidbody>() && heldObj == null)
        {
            heldObj = pickUpObj;
            heldObjRb = pickUpObj.GetComponent<Rigidbody>();
            heldObjRb.isKinematic = true;
            heldObjRb.transform.parent = holdPosition.transform;
            heldObj.layer = holdLayerNumber;
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        }
    }

    private void DropObject()
    {
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0;
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null;
        heldObj = null;
    }

    private void MoveObject()
    {
        heldObj.transform.position = holdPosition.transform.position;
    }

    private void RotateObject()
    {
        if (Input.GetKey(KeyCode.R))
        {
            canDrop = false;
            float xAxisRotation = Input.GetAxis("Mouse X") * rotationSensitivity;
            float yAxisRotation = Input.GetAxis("Mouse Y") * rotationSensitivity;
            heldObj.transform.Rotate(Vector3.down, xAxisRotation);
            heldObj.transform.Rotate(Vector3.right, yAxisRotation);
        }
        else
        {
            canDrop = true;
        }
    }

    private void ThrowObject()
    {
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0;
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