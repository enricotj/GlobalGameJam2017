using UnityEngine;
using System.Collections;

public class PlayerInputComponent : InputComponent {

    public override void ReadInputs(ActorComponent actor)
    {
        // move
        float dx = 0;
        float dy = 0;
        if (Input.GetKey(KeyCode.W))
            dy += 1;
        if (Input.GetKey(KeyCode.A))
            dx -= 1;
        if (Input.GetKey(KeyCode.S))
            dy -= 1;
        if (Input.GetKey(KeyCode.D))
            dx += 1;
        actor.MovementIntent = (new Vector2(dx, dy)).normalized;

        // look
        //Camera camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        //Vector2 positionOnScreen = camera.WorldToViewportPoint(actor.Position);
        //Vector2 mouseOnScreen = (Vector2)camera.ScreenToViewportPoint(Input.mousePosition);
        //actor.RotationIntent = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen) + 180;

        // attack/act
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetMouseButtonDown(0))
            {
                //actor.Attack();
            }
            else if (Input.GetMouseButtonDown(1))
            {

            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {

            }
            else if (Input.GetMouseButtonDown(1))
            {

            }
        }
    }

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

}
