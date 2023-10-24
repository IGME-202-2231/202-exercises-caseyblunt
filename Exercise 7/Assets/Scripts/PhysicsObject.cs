using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PhysicsObject : MonoBehaviour
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private Vector3 position;
    [SerializeField] private Vector3 velocity;

    [SerializeField] private Vector3 acceleration = Vector3.zero;
    [SerializeField] private float mass = 1;

    [SerializeField] float maxSpeed = 10f;

    bool isFrictionOn;


    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the velocity for this frame - New
        velocity += acceleration * Time.deltaTime;

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        position += velocity * Time.deltaTime;

        // Grab current direction from velocity  - New
        direction = velocity.normalized;

        transform.position = position;

        // Zero out acceleration - New
        acceleration = Vector3.zero;

    }

    public void ApplyForce(Vector3 force)
    {
        acceleration += force / mass;
    }


    void ApplyGravity(Vector3 force)
    {
        acceleration += force;
    }

    void ApplyFriction(float coeff)
    {
        Vector3 friction = velocity * -1;
        friction.Normalize();
        friction = friction * coeff;
        ApplyForce(friction);
    }

}
