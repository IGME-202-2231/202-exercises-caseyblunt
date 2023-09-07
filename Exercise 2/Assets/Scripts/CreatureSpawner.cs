using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{
    [SerializeField] GameObject creaturePrefab;
    [SerializeField] float posX;
    [SerializeField] float posZ;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            posX = Random.Range(-33.0f, 33.0f);
            posZ = Random.Range(-33.0f, 33.0f);
            pos = new Vector3(posX, 1.46f, posZ);
            Instantiate(creaturePrefab);
            creaturePrefab.transform.position = pos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
