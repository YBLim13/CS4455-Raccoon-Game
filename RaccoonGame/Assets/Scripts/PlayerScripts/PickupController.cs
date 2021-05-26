using UnityEngine;
using UnityEngine.InputSystem;

public class PickupController : MonoBehaviour
{
    /*
    [SerializeField]
    private Camera characterCamera;
    [SerializeField]
    private Transform slot;
    private Pickable pickedItem;
    public TextMeshProUGUI currObj;
    */

    private Vector3 _startPos;
    private Vector3 _endPos;
    private CapsuleCollider _capsule;
    private Collider[] _collisions;
    private Collider _latestSelection;
    private Vector3 dropVector;
    public static int myInt = 0;

    void Start()
    {
        _capsule = GetComponent<CapsuleCollider>();
    }

    void FixedUpdate()
    {
        dropVector = -1 * transform.forward * _capsule.height + new Vector3(0f, 0.5f, 0f);
        // Forward vector is (0, 0, 1), then multiply by height/2 to get from center to edge of capsule
        Vector3 toSphereCenter = this.transform.forward * _capsule.height / 2;
        _startPos = this.transform.position + toSphereCenter;
        _endPos = this.transform.position + (-1 * toSphereCenter);

        int layerMask = 1 << 8;  // LayerMask for PickupableItem

        _collisions = Physics.OverlapCapsule(_startPos, _endPos, _capsule.radius * 2, layerMask);
        
        if (_collisions.Length != 0) {
            _latestSelection = _collisions[0];
        } else {
            _latestSelection = null;
        }
    }

    void OnPickup()
    {
        if (_latestSelection != null) {
            GameObject obj = _latestSelection.gameObject;
            obj.SetActive(!InventoryManager.Instance.AddItem(obj));
            myInt += 1;
            print(myInt);

        }

        /*
        if (pickedItem)
        {
            DropItem(pickedItem);
        }
        else
        {
            var ray = characterCamera.ViewportPointToRay(Vector3.one * 0.5f);
            RaycastHit hit;
            Debug.Log(Physics.Raycast(ray, out hit, 3f));
            if (Physics.Raycast(ray, out hit, 3f))
            {
                var pickable = hit.transform.GetComponent<Pickable>();
                Debug.Log(hit.collider.gameObject.name);

                if (pickable)
                {
                    PickItem(pickable);
                }
            }
        }
        */
    }

    void OnDrop()
    {
        GameObject dropped = InventoryManager.Instance.DropItem();  // Implicitly index = 0 for now

        if (dropped != null) {
            dropped.SetActive(true);
            dropped.GetComponent<Rigidbody>().MovePosition(transform.position + dropVector);
            dropped.transform.rotation = Quaternion.identity;
        }
    }

/*
    private void PickItem(Collider item)
    {
        pickedItem = item;
        item.Rb.isKinematic = true;
        item.Rb.velocity = Vector3.zero;
        item.Rb.angularVelocity = Vector3.zero;
        item.transform.SetParent(slot);
        item.transform.localPosition = new Vector3(0f, 0f, -3.5f);
        item.transform.localEulerAngles = Vector3.zero;
        string name = item.gameObject.name;

        currObj.text = "Current Object: " + name;
    }

    private void DropItem(Collider item)
    {
        pickedItem = null;

        item.transform.SetParent(null);

        item.Rb.isKinematic = false;

        item.Rb.AddForce(item.transform.forward * 2, ForceMode.VelocityChange);

        currObj.text = "Current Object: none";

    }
*/
}