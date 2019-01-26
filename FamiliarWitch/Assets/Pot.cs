using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : ThoughtGenerator
{
    private bool ContainsMushroom = false;
    
    protected override void ChooseThought()
    {
        if (!ContainsMushroom)
        {
            CurrentThoughtID = 0;
        }
    }

}