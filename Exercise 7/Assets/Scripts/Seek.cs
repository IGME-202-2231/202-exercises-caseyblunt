using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : Agent
{
    [SerializeField] GameObject target;

    protected override void CalcSteeringForces()
    {
        myPhysicsObject.ApplyForce(Seek(target));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position, transform.position + myPhysicsObject.Velocity);
    }
}
