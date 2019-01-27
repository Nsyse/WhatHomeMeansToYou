using UnityEngine;

public abstract class ThoughtGenerator : MonoBehaviour
{
    public GameObject[] RelatedThoughts;

    protected int CurrentThoughtID = -1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Choose which thought to spawn
        UpdateThought();
        
        //Spawn thought if any decision could be made
        if (CurrentThoughtID != -1)
        {
            SpawnThought();
        }
    }

    protected void UpdateThought()
    {
        CurrentThoughtID = -1;
        ChooseThought();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        DespawnThought();
    }

    protected abstract void ChooseThought();

    protected void DespawnThought()
    {
        //No need to despawn a thought if there's no active thought.
        if (CurrentThoughtID != -1)
        {
            if(CurrentThoughtID>= RelatedThoughts.Length){
                Debug.LogError("Error : Despawned thought out of bounds, caused by caller : "+GetCallerName());
            }
            else
            {
                ThoughtsManager.DeleteThought(RelatedThoughts[CurrentThoughtID]);
            }
        }
    }
    
    private void SpawnThought()
    {
        if (CurrentThoughtID == -1)
        {
            Debug.LogError("Error : Thought spawner doesn't know what to spawn!!");
        }
        else if(CurrentThoughtID>= RelatedThoughts.Length){
            Debug.LogError("Error : Spawned thought out of bounds, caused by caller : "+GetCallerName());
        }
        else
        {
            ThoughtsManager.FireThought(RelatedThoughts[CurrentThoughtID]);
        }
    }
    
    private string GetCallerName()
    {
        return this.GetType().ToString();
    }
}