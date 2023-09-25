using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Vector3 objectPos = Vector3.zero;
    Vector3 direction = Vector3.right;
    Vector3 velocity = Vector3.zero;
    [SerializeField] float speed = 1.0f;
    float minX, maxX, minY, maxY;

    void Start()
    {
        objectPos = transform.position;

        // Calculate screen boundaries
        Camera mainCamera = Camera.main;
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
        velocity = direction * speed * Time.deltaTime;

        objectPos += velocity;

        // Wrap around when reaching the screen borders
        if (objectPos.x < minX) objectPos.x = maxX;
        if (objectPos.x > maxX) objectPos.x = minX;
        if (objectPos.y < minY) objectPos.y = maxY;
        if (objectPos.y > maxY) objectPos.y = minY;

        // Update position
        transform.position = objectPos;
    }

    public void SetDirection(Vector3 newDirection)
    {
        if (newDirection != null)
        {
            direction = newDirection.normalized;

            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(Vector3.back, direction);
            }
        }
    }
}
