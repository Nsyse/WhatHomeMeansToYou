using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObjectThought : MonoBehaviour
{
    [SerializeField]
    private GameObject ObjectToPickup;
    
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            PickupObject();
        }
    }

    private void PickupObject()
    {
        ObjectToPickup.transform.parent = Varianne.Instance.gameObject.GetComponentInChildren<HeldItemSlot>().transform;
        ObjectToPickup.transform.position = Varianne.Instance.gameObject.GetComponentInChildren<HeldItemSlot>().transform.position;
    }
}
