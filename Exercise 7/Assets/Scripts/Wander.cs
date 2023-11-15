using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : Agent
{
    protected override void CalcSteeringForces()
    {
        totalForce += Wander(1f, 2f);
        totalForce += StayInBounds();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position, transform.position + myPhysicsObject.Velocity);
    }
}
