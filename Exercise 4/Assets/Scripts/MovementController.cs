using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Vector3 objectPos = Vector3.zero;
    Vector3 direction = Vector3.right;
    Vector3 velocity = Vector3.zero;
    [SerializeField] float speed = 1.0f;
    void Start()
    {
        objectPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed * Time.deltaTime;

        objectPos += velocity;

        //Check position
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
