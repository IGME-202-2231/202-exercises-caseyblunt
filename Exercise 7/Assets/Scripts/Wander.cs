using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : Agent
{
    [Min(1f)]
    public float stayInBoundsWeight = 3f;

    public float wanderWeight = 1f;
    protected override void CalcSteeringForces()
    {
        Wander(wanderWeight);
        StayInBounds(stayInBoundsWeight);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position, transform.position + myPhysicsObject.Velocity);
    }
}
