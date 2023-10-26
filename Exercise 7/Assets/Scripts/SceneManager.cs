using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SceneManager : MonoBehaviour
{
    public List<PhysicsObject> PhysicsObjects;

    Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Camera cam = Camera.main;
        mousePos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePos.z = 0;

        foreach (var obj in PhysicsObjects)
        {
            obj.ApplyForce(mousePos - PhysicsObjects[0].transform.position);
        }
    }
}
