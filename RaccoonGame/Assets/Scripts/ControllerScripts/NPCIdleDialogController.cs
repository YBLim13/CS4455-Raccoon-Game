using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCIdleDialogController : MonoBehaviour
{
    public CapsuleCollider _collider;

    [SerializeField]
    private GameObject idle0;
    [SerializeField]
    private GameObject idle1to13;
    [SerializeField]
    private GameObject idle14;
    private int numItems;


    // Start is called before the first frame update
    void Start()
    {
        idle0.SetActive(false);
        idle1to13.SetActive(false);
        idle14.SetActive(false);
        numItems = InventoryManager.Instance.inventory.Count;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player" && !CutsceneManager.Instance.isCutscene()) {
            if (numItems == 0) {
                idle0.SetActive(true);
            } else if (numItems > 0 && numItems < 14) {
                idle1to13.SetActive(true);
            } else if (numItems == 14) {
                idle14.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player" && !CutsceneManager.Instance.isCutscene()) {
            if (numItems == 0) {
                idle0.SetActive(false);
            } else if (numItems > 0 && numItems < 14) {
                idle1to13.SetActive(false);
            } else if (numItems == 14) {
                idle14.SetActive(false);
            }
        }
    }
}
