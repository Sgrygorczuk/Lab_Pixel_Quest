using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barriervisiblity : MonoBehaviour
{
    public string targetTag = "Enemy";
    

    private Renderer objectRenderer;
    // Start is called before the first frame update
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        SetVisibility(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag))
        {
            SetVisibility(false);
        }
    }

    public void SetVisibility(bool isVisible)
    {
        if (objectRenderer != null)
        {
            objectRenderer.enabled = isVisible;
        }
    }

    public bool IsVisible() {
        return objectRenderer.enabled;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left-click
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);
                if (hit.transform == this.transform)
                {
                    SetVisibility(true);
                }
            }
        }
    }
    void ToggleVisibility()
    {
        if (objectRenderer != null)
        {
            objectRenderer.enabled = !objectRenderer.enabled;
        }
    }
}
