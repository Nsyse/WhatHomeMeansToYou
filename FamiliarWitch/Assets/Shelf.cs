using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shelf : ThoughtGenerator
{
    [SerializeField] private GameObject[] ShelfSlots;

    private void AddContent(PickableItem item)
    {
        int firstEmptyIndex = -1;

        bool searchComplete = false;
        for (int i = 0; i < ShelfSlots.Length && !searchComplete; i++)
        {
            PickableItem containedItem = ShelfSlots[i].GetComponentInChildren<PickableItem>();
            if (containedItem == null)
            {
                firstEmptyIndex = i;
                searchComplete = true;
            }
        }

        //Set the object's parent
        item.gameObject.transform.parent = ShelfSlots[firstEmptyIndex].transform;
    }

    protected override void ChooseThought()
    {
        bool containsMushroom = false;
        bool containsPotion = false;

        foreach (GameObject shelfSlot in ShelfSlots)
        {
            PickableItem contained = shelfSlot.GetComponentInChildren<PickableItem>();
            if (contained != null)
            {
                if (contained.GetType() == typeof(Potion))
                {
                    containsPotion = true;
                }

                if (contained.GetType() == typeof(Mushroom))
                {
                    containsMushroom = true;
                }
            }
        }

        if (containsMushroom && containsPotion)
        {
            CurrentThoughtID = 0;
        }
        else if (containsMushroom)
        {
            CurrentThoughtID = 1;
        }
        else if (containsPotion)
        {
            CurrentThoughtID = 2;
        }
    }
}