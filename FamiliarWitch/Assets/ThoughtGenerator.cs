using UnityEngine;

public abstract class ThoughtGenerator : MonoBehaviour
{
    public GameObject[] RelatedThoughts;
 
    protected int CurrentThoughtID = -1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        ChooseThought();
        SpawnThought();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        DespawnThought();
    }
    
    protected void SpawnThought()
    {
        ThoughtsManager.FireThought(RelatedThoughts[CurrentThoughtID]);
    }

    protected abstract void ChooseThought();

    protected void DespawnThought()
    {
        ThoughtsManager.DeleteThought(RelatedThoughts[CurrentThoughtID]);
    }
}