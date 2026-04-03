using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spriteplacer : MonoBehaviour
{
    public GameObject spritePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))  // Right mouse button (button 1)
        {
            PlaceSpriteAtMousePosition();
        }
    }

    void PlaceSpriteAtMousePosition()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);  // Get mouse position in world space
        Instantiate(spritePrefab, mousePosition, Quaternion.identity);  // Place the sprite at the mouse position
    }
}
