using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorVisibility : MonoBehaviour
{
    public float InteractibleThreshold;

    public float MinTransparency;
    public float MinVisibleThreshold;
    public float MaxisibleThreshold;
    
    // Update is called once per frame
    void Update()
    {
        UpdateVisibility();
    }

    private void UpdateVisibility()
    {
        float distance = DistanceToVarianne();
        if (distance > MinVisibleThreshold)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
            
        }
        else
        {
            float opacity = 1 - Mathf.Pow(distance/ MinVisibleThreshold, 2);
            
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,opacity);
        }
    }

    private float DistanceToVarianne()
    {
        GameObject varianne = GameObject.FindWithTag("Player");
        
        return Vector2.Distance(gameObject.transform.position, varianne.transform.position);;
    }
}
