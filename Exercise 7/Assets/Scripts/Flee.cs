using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : Agent
{
    [SerializeField] GameObject target;

    protected override void CalcSteeringForces()
    {
        myPhysicsObject.ApplyForce(Flee(target));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position, transform.position + myPhysicsObject.Velocity);
    }

    public void ResetPosition()
    {
        float yPos = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        float xPos = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

        transform.position = new Vector3(xPos, yPos, 0);
    }
}
