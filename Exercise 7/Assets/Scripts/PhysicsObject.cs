using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PhysicsObject : MonoBehaviour
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private Vector3 position;
    [SerializeField] private Vector3 velocity;
    float minX;
    float maxX;
    float minY;
    float maxY;
    Camera mainCamera;
    [SerializeField] private Vector3 acceleration = Vector3.zero;
    [SerializeField] private float mass = 1;

    [SerializeField] float maxSpeed = 10f;

    bool isFrictionOn;


    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        mainCamera = Camera.main;
        float objectWidth = GetComponent<Renderer>().bounds.size.x;
        float objectHeight = GetComponent<Renderer>().bounds.size.y;
        minX = mainCamera.ViewportToWorldPoint(Vector3.zero).x + objectWidth / 2;
        maxX = mainCamera.ViewportToWorldPoint(Vector3.one).x - objectWidth / 2;
        minY = mainCamera.ViewportToWorldPoint(Vector3.zero).y + objectHeight / 2;
        maxY = mainCamera.ViewportToWorldPoint(Vector3.one).y - objectHeight / 2;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForBounce();

        ApplyGravity(Vector3.down * 9.81f);
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

    void CheckForBounce()
    {
        if (position.x <= minX)
        {
            velocity.x *= -1;

            position.x = minX;
        }
        else if (position.x >= maxX)
        {
            velocity.x *= -1;

            position.x = maxX;
        }
        
        if (position.y <= minY)
        {
            velocity.y *= -1;

            position.y = minY;
        }
        else if (position.y >= maxY)
        {
            velocity.y *= -1;

            position.y = maxY;
        }
    }

}