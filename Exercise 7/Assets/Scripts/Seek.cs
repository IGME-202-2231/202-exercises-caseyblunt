using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : Agent
{
    [SerializeField] GameObject target;

    protected override void CalcSteeringForces()
    {
        //Seek(target, stayInBoundsWeight);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position, transform.position + myPhysicsObject.Velocity);
    }
}
