using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shelf : ThoughtGenerator
{
    private List<PickableItem> containedItems = new List<PickableItem>();
    
    protected override void ChooseThought()
    {
        bool containsMushroom = false;
        bool potion = false;

        foreach (var item in containedItems)
        {
//            if ()
//            {
//                
//            }
        }
    }
}