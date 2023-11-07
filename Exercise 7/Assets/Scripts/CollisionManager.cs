using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public SpriteInfo fleer;
    public SpriteInfo seeker;

    // Update is called once per frame
    void Update()
    {
        bool isColliding = CircleCollision(seeker, fleer);

        if (isColliding)
        {
            //fleer.gameObject.GetComponent<Flee>().ResetPosition();
        }
    }

    bool CircleCollision(SpriteInfo sprite1, SpriteInfo sprite2)
    {
        float radius1 = sprite1.SpriteSize.x / 2f;
        float radius2 = sprite2.SpriteSize.x / 2f;

        float distance = Vector2.Distance(sprite1.transform.position, sprite2.transform.position);

        return distance <= (radius1 + radius2);
    }
}
