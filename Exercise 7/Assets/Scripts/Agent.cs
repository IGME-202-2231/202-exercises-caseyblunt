using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public abstract class Agent : MonoBehaviour
{
    [SerializeField] PhysicsObject myPhysicsObject;
    [SerializeField] Vector3 position;
    [SerializeField] Vector3 velocity;
    [SerializeField] Vector3 direction;

    int maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalcSteeringForces();
    }

    protected abstract void CalcSteeringForces();

    Vector3 Seek(Vector3 targetPos)
    {
        // Calculate desired velocity
        Vector3 desiredVelocity = targetPos - transform.position;

        // Set desired = max speed
        desiredVelocity = desiredVelocity.normalized * maxSpeed; //change to myPhysicsObject.MaxSpeed; after adding!

        // Calculate seek steering force
        Vector3 seekingForce = desiredVelocity - velocity; //change to myPhysicsObject.Velocity!!

        // Return seek steering force
        return seekingForce;

    }

    Vector3 Seek(GameObject target)
    {
        return Seek(target.transform.position);
    }
}
