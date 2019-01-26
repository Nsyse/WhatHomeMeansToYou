using UnityEngine;

public class FreeRoamState : VarianneState
{
    public override void ExecuteState(int leftRightIntent, int upDownIntent, Varianne varianne)
    {
        Walk(leftRightIntent, varianne);
        NoteInteractible();
    }

    private void NoteInteractible()
    {
        //TODO
    }

    private void Walk(int leftRightIntent, Varianne varianne)
    {
        Vector2 currentVelocity = varianne.gameObject.GetComponent<Rigidbody2D>().velocity;
        varianne.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(leftRightIntent * varianne.Speed, currentVelocity.y);
    }
}