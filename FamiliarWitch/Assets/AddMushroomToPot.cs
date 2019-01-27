using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMushroomToPot : MonoBehaviour
{
    [SerializeField]
    private GameObject ObjectToDestroy;
    
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            DestroyHeldMushroom();
        }
    }

    private void DestroyHeldMushroom()
    {
        Pot.FireAddMushroom();
        Varianne.Instance.DestroyHeldItem();
    }
}
