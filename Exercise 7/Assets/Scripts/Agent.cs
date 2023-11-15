using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    [SerializeField] protected PhysicsObject myPhysicsObject;
    [SerializeField] Vector3 position;
    [SerializeField] Vector3 velocity;
    [SerializeField] Vector3 direction;

    int maxSpeed;

    private Vector3 totalForce = Vector3.zero;
    public float maxForce = 5f;

    private float wanderAngle = 0f;

    public float maxWanderAngle = 45f;

    public float maxWanderChangePerSecond = 10f;

    // Update is called once per frame
    void Update()
    {
        CalcSteeringForces();

        totalForce = Vector3.ClampMagnitude(totalForce, maxForce);
        myPhysicsObject.ApplyForce(totalForce);

        totalForce = Vector3.zero;
    }

    protected abstract void CalcSteeringForces();

    protected void Seek(Vector3 targetPos, float weight = 1f)
    {
        // Calculate desired velocity
        Vector3 desiredVelocity = targetPos - myPhysicsObject.Position;

        // Set desired = max speed
        desiredVelocity = desiredVelocity.normalized * myPhysicsObject.MaxSpeed;

        // Calculate seek steering force
        Vector3 seekingForce = desiredVelocity - myPhysicsObject.Velocity;

        // Return seek steering force
        totalForce += seekingForce * weight;

    }

    /*protected Vector3 Seek(GameObject target)
    {
        return Seek(target.transform.position);
    }*/

    Vector3 Flee(Vector3 targetPos)
    {
        // Calculate desired velocity
        Vector3 desiredVelocity = transform.position - targetPos;

        // Set desired = max speed
        desiredVelocity = desiredVelocity.normalized * myPhysicsObject.MaxSpeed;

        // Calculate flee steering force
        Vector3 fleeingForce = desiredVelocity - myPhysicsObject.Velocity;

        // Return flee steering force
        return fleeingForce;
    }

    protected Vector3 Flee(GameObject target)
    {
        return Flee(target.transform.position);
    }

    protected void Wander(float weight = 1f)
    {
        //Update the angle of current wander
        float maxWanderChange = maxWanderChangePerSecond * Time.deltaTime;
        wanderAngle += Random.Range(-maxWanderChange, maxWanderChange);

        wanderAngle = Mathf.Clamp(wanderAngle, -maxWanderAngle, maxWanderAngle);
        //get position that is defined by wander angle
        Vector3 wanderTarget = Quaternion.Euler(0, 0, wanderAngle) * myPhysicsObject.Direction.normalized + myPhysicsObject.Position;
        //seek towards wander position
        Seek(wanderTarget, weight);
    }

    // New function for GetFuturePosition
    public Vector3 GetFuturePosition(float secondsAhead = 1f)
    {
        return myPhysicsObject.Position + myPhysicsObject.Velocity * secondsAhead;
    }

    protected void StayInBounds(float weight = 1f)
    {
        Vector3 futurePos = GetFuturePosition();

        if (futurePos.x > myPhysicsObject.CameraSize.x ||
            futurePos.x < - myPhysicsObject.CameraSize.x ||
            futurePos.y > myPhysicsObject.CameraSize.y ||
            futurePos.y < - myPhysicsObject.CameraSize.y)
        {
            Seek(Vector3.zero, weight);
        }

        
    }
}
