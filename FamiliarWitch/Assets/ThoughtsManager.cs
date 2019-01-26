using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtsManager : MonoBehaviour
{
    public delegate void ThinkingAbout(GameObject thoughtGOName, bool active);

    public static event ThinkingAbout OnThoughtSpawned;
    public static event ThinkingAbout OnThoughtDespawned;

    [SerializeField] private GameObject ThoughtBubble = null;

    [SerializeField] private List<GameObject> ActiveThoughts = new List<GameObject>();

    public static ThoughtsManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        OnThoughtSpawned += UpdateThought;
        OnThoughtDespawned += UpdateThought;
    }

    private void UpdateThought(GameObject thought, bool active)
    {
        if (active)
        {
            ActiveThoughts.Add(thought);
        }
        else
        {
            ActiveThoughts.Remove(thought);
        }

        if (ActiveThoughts.Count == 0)
        {
            HideThoughts();
        }
        else
        {
            DisplayActiveThought();
        }
    }

    private void HideThoughts()
    {
        ThoughtBubble.SetActive(false);
        foreach (var thought in ActiveThoughts)
        {
            thought.SetActive(false);
        }
    }

    private void DisplayActiveThought()
    {
        HideThoughts();
        
        ThoughtBubble.SetActive(true);
        ActiveThoughts[ActiveThoughts.Count - 1].SetActive(true);
    }

    public static void FireThought(GameObject thought)
    {
        OnThoughtSpawned?.Invoke(thought, true);
    }

    public static void DeleteThought(GameObject thought)
    {
        OnThoughtDespawned?.Invoke(thought, false);
    }
}