using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week_2_demo : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] public string name;
    [SerializeField] GameObject creaturePrefab;
    // Start is called before the first frame update
    void Start()
    {
        name = "bob";
        health = 10;
        Instantiate(creaturePrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
