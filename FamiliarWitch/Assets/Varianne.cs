using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Varianne : MonoBehaviour
{
    public int Speed = 0;
    
    private int leftRightIntent = 0;
    private int upDownIntent = 0;
    
    private VarianneState CurrentState = new FreeRoamState();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RegisterInputIntents();

        ExecuteStateWithInputs();
    }

    private void ExecuteStateWithInputs()
    {
        CurrentState.ExecuteState(leftRightIntent, upDownIntent, this);
    }

    private void RegisterInputIntents()
    {
        leftRightIntent = 0;
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            leftRightIntent = -1;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            leftRightIntent++;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            upDownIntent = -1;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            upDownIntent++;
        }
    }
}