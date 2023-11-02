using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionManager : MonoBehaviour
{
    public List<GameObject> obstacles;

    // Start is called before the first frame update
    void Start()
    {
        obstacles = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
            // Loop through each obstacle and check for collision with the player
            for (int i = 0; i < obstacles.Count; i++)
            {
                GameObject obj1 = obstacles[i];
                for (int j = 0; j < obstacles.Count; j++)
                {
                    GameObject obj2 = obstacles[j];

                    if (obj1 == obj2)
                    {
                        continue;
                    }

                    //ARE THESE COLLIDING??????
                    bool isColliding = CircleCollision(obj1.GetComponent<SpriteInfo>(), obj2.GetComponent<SpriteInfo>());

                    //if not colliding, continue
                    if (!isColliding)
                    {
                        continue;
                    }

                    if (obj1.CompareTag("Fleer"))
                    {
                        if (obj2.CompareTag("Seeker"))
                        {
                            Debug.Log("Collided!");
                            ResetPosition(obj1);

                        }
                    }

                    else if (obj1.CompareTag("Seeker"))
                    {
                        if (obj2.CompareTag("Fleer"))
                        {
                            Debug.Log("Collided!");
                            ResetPosition(obj2);
                        }

                    }
                }
            }
    }

    bool CircleCollision(SpriteInfo sprite1, SpriteInfo sprite2)
    {
        float radius1 = sprite1.SpriteSize.x / 2f;
        float radius2 = sprite2.SpriteSize.x / 2f;

        float distance = Vector2.Distance(sprite1.transform.position, sprite2.transform.position);

        return distance <= (radius1 + radius2);
    }

    void ResetPosition(GameObject item)
    {
        float yPos = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        float xPos = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

        item.transform.position = new Vector3(xPos, yPos, 0);
    }

}
