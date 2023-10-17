using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : Singleton<SpawnManager>
{
    [SerializeField] List<Sprite> creatureSprites; // Reference to creature sprites
    [SerializeField] GameObject creaturePrefab; // Prefab for the creature
    [SerializeField] int numberOfCreaturesToSpawn; // Number of creatures to spawn
    public Button spawnButton;

    private List<GameObject> spawnedCreatures = new List<GameObject>(); // Keep track of spawned creatures

    protected SpawnManager() { }

    void Start()
    {
        SpawnCreatures(); //calls SpawnCreatures once on start
    }

    void Update()
    {
        
    }

    public void SpawnCreatures() //picks random number of creatures to spawn and then calls SpawnCreature() that many number of times
    {
        numberOfCreaturesToSpawn = Random.Range(10, 20);
        CleanUp();
        for (int i = 0; i < numberOfCreaturesToSpawn; i++)
        {
            SpawnCreature();
        }
    }

    void SpawnCreature()
    {
        GameObject newCreature = Instantiate(creaturePrefab, GetRandomSpawnPosition(), Quaternion.identity);
        SpriteRenderer spriteRenderer = newCreature.GetComponent<SpriteRenderer>();

    /*Picks random decimal between 0 and 1. Creature Spawns are skewed as follows:
        - Elephant: 25 %
        - Turtle: 20 %
        - Snail: 15 %
        - Octopus: 10 %
        - Kangaroo: 30 %
    */

    float rng = Random.Range(0f, 1f);

        if (rng <= 0.25)
        {
            spriteRenderer.sprite = creatureSprites[0];
        }
        else if (rng <= 0.45)
        {
            spriteRenderer.sprite = creatureSprites[1];
        }
        else if (rng <= 0.6)
        {
            spriteRenderer.sprite = creatureSprites[2];
        }
        else if (rng <= 0.7)
        {
            spriteRenderer.sprite = creatureSprites[3];
        }
        else
        {
            spriteRenderer.sprite = creatureSprites[4];
        }
        
        //Assigns random color then adds to spawnedCreatures list
        Color randomColor = new Color(Random.value, Random.value, Random.value);
        spriteRenderer.color = randomColor;

        spawnedCreatures.Add(newCreature);
    }

    Vector3 GetRandomSpawnPosition() //calculates random spawn position using the Gaussian() method provided
    {
        float x = Gaussian(1f, 10f);
        float y = Gaussian(1f, 10f);
        return new Vector3(x, y, 0);
    }

    void CleanUp() //Deletes all creatures in scene
    {
        foreach (GameObject creature in spawnedCreatures)
        {
            Destroy(creature);
        }
        spawnedCreatures.Clear();
    }

    private float Gaussian(float mean, float stdDev) //Provided Gaussian distribution method
    {
        float val1 = Random.Range(0f, 1f);
        float val2 = Random.Range(0f, 1f);

        float gaussValue =
        Mathf.Sqrt(-2.0f * Mathf.Log(val1)) *
        Mathf.Sin(2.0f * Mathf.PI * val2);

        return mean + stdDev * gaussValue;
    }

}

