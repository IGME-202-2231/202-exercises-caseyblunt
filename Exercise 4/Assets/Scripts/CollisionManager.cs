using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public enum CollisionMode
{
    AABB,
    Circle
}

public class CollisionManager : MonoBehaviour
{
    public CollisionMode activeCollisionMode = CollisionMode.AABB;
    public SpriteInfo[] obstacles;
    public SpriteInfo player;
    public TextMeshProUGUI text;

    void Update()
    {
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            // Toggle between AABB and Circle collision modes
            activeCollisionMode = (activeCollisionMode == CollisionMode.AABB) ? CollisionMode.Circle : CollisionMode.AABB;

            if (text != null)
            {
                text.text = "Collision Mode: " + activeCollisionMode;
            }
        }

        bool playerIsColliding = false;

        foreach (SpriteInfo obstacle in obstacles)
        {
            bool isColliding = false;

            // Choose the appropriate collision method based on the active mode
            if (activeCollisionMode == CollisionMode.AABB)
            {
                isColliding = AABBCollision(obstacle, player);
            }
            else if (activeCollisionMode == CollisionMode.Circle)
            {
                isColliding = CircleCollision(obstacle, player);
            }

            // Change the color 
            obstacle.spriteRenderer.color = isColliding ? Color.red : Color.white;

            playerIsColliding = playerIsColliding || isColliding;
        }

        player.spriteRenderer.color = playerIsColliding ? Color.red : Color.white;
    }

    bool AABBCollision(SpriteInfo sprite1, SpriteInfo sprite2)
    {
        bool collisionX = sprite1.MaxX >= sprite2.MinX && sprite1.MinX <= sprite2.MaxX;
        bool collisionY = sprite1.MaxY >= sprite2.MinY && sprite1.MinY <= sprite2.MaxY;

        return collisionX && collisionY;
    }

    bool CircleCollision(SpriteInfo sprite1, SpriteInfo sprite2)
    {
        float radius1 = sprite1.SpriteSize.x / 2f;
        float radius2 = sprite2.SpriteSize.x / 2f; 

        float distance = Vector2.Distance(sprite1.transform.position, sprite2.transform.position);

        return distance <= (radius1 + radius2);
    }
}

