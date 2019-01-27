using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Pot : ThoughtGenerator
{
    public delegate void AddMushroomEvent();
    public static event AddMushroomEvent OnMushroomAdded;
    
    private bool ContainsMushroom = false;

    private void OnEnable()
    {
        OnMushroomAdded += AddMushroom;
    }

    private void OnDisable()
    {
        OnMushroomAdded -= AddMushroom;
    }

    private void AddMushroom()
    {
        ContainsMushroom = true;
        UpdateThought();
    }

    protected override void ChooseThought()
    {
        if (!ContainsMushroom && !Varianne.Instance.IsHolding<Mushroom>())
        {
            CurrentThoughtID = 0;
        }
        else if (!ContainsMushroom && Varianne.Instance.IsHolding<Mushroom>())
        {
            CurrentThoughtID = 1;
        }
    }

    public static void FireAddMushroom()
    {
        OnMushroomAdded?.Invoke();
    }
}