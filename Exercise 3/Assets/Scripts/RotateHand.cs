using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHand : MonoBehaviour
{
    private float turnAmount;
    private float turnSpeed;
    [SerializeField] private Boolean useDeltaTime;
    // Start is called before the first frame update
    void Start()
    {
        turnAmount = 6;
        turnSpeed = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if (useDeltaTime)
        {
            transform.rotation = (Quaternion.Euler(0, 0, turnAmount));
            turnAmount -= turnSpeed * Time.deltaTime;
        }
        else
        {
            transform.rotation = (Quaternion.Euler(0, 0, turnAmount));
            turnAmount -= turnSpeed;
        }
    }
}
