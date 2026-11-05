using UnityEngine;
using UnityEngine.UI;

public class DVDBounce : MonoBehaviour
{
    public float speed = 200f; // Speed of the logo inside Canvas space
    
    private RectTransform logoRect;
    private RectTransform canvasRect;
    private RawImage logoImage;
    
    private Vector2 velocity;
    private float halfWidth;
    private float halfHeight;

    void Start()
    {
        logoRect = GetComponent<RectTransform>();
        // Grab the parent Canvas RectTransform
        canvasRect = transform.parent.GetComponent<RectTransform>();
        logoImage = GetComponent<RawImage>();

        // Calculate half-sizes for boundary collision
        halfWidth = logoRect.rect.width / 2f;
        halfHeight = logoRect.rect.height / 2f;

        // Start moving in a random diagonal direction
        float randomX = Random.Range(0, 2) == 0 ? -1f : 1f;
        float randomY = Random.Range(0, 2) == 0 ? -1f : 1f;
        velocity = new Vector2(randomX, randomY).normalized * speed;
        
        ChangeColor();
    }

    void Update()
    {
        // Move the logo in UI/Canvas space
        logoRect.anchoredPosition += velocity * Time.deltaTime;

        // Calculate current limits based on the Canvas size
        float minX = (-canvasRect.rect.width / 2f) + halfWidth;
        float maxX = (canvasRect.rect.width / 2f) - halfWidth;
        float minY = (-canvasRect.rect.height / 2f) + halfHeight;
        float maxY = (canvasRect.rect.height / 2f) - halfHeight;

        Vector2 pos = logoRect.anchoredPosition;
        bool hitWall = false;

        // Check horizontal boundaries
        if (pos.x <= minX)
        {
            pos.x = minX;
            velocity.x = Mathf.Abs(velocity.x); // Bounce right
            hitWall = true;
        }
        else if (pos.x >= maxX)
        {
            pos.x = maxX;
            velocity.x = -Mathf.Abs(velocity.x); // Bounce left
            hitWall = true;
        }

        // Check vertical boundaries
        if (pos.y <= minY)
        {
            pos.y = minY;
            velocity.y = Mathf.Abs(velocity.y); // Bounce up
            hitWall = true;
        }
        else if (pos.y >= maxY)
        {
            pos.y = maxY;
            velocity.y = -Mathf.Abs(velocity.y); // Bounce down
            hitWall = true;
        }

        // Apply updated position
        logoRect.anchoredPosition = pos;

        // Change color on bounce
        if (hitWall)
        {
            ChangeColor();
        }
        hitWall = false;
    }

    void ChangeColor()
    {
        // Generates a random bright saturated color
        logoImage.color = Color.HSVToRGB(Random.value, 1f, 1f);
    }
}
