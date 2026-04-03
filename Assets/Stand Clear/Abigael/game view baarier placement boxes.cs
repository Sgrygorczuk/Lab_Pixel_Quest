using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameviewbaarierplacementboxes : MonoBehaviour
{
    public Rect allowedScreenArea;  // The screen area to draw
    private Camera mainCamera;
    private LineRenderer lineRenderer;

    void Awake()
    {
        mainCamera = Camera.main;  // Cache the reference to Camera.main
        lineRenderer = GetComponent<LineRenderer>();  // Get LineRenderer attached to this GameObject
    }
    // Start is called before the first frame update
    void Start()
    {
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();  // Add LineRenderer if it doesn't exist
        }

        lineRenderer.positionCount = 5;  // 4 points for the box + 1 for closing the loop
        lineRenderer.startWidth = 0.05f;  // Line width
        lineRenderer.endWidth = 0.05f;

        // Set the box color (Optional)
        lineRenderer.startColor = Color.yellow;
        lineRenderer.endColor = Color.yellow;

        // Update the box
        UpdateBox();
    }

    void UpdateBox()
    {
        // Convert the screen space coordinates to world space
        Vector3 bottomLeft = mainCamera.ScreenToWorldPoint(new Vector3(allowedScreenArea.xMin, allowedScreenArea.yMin, mainCamera.nearClipPlane + 1));
        Vector3 topLeft = mainCamera.ScreenToWorldPoint(new Vector3(allowedScreenArea.xMin, allowedScreenArea.yMax, mainCamera.nearClipPlane + 1));
        Vector3 topRight = mainCamera.ScreenToWorldPoint(new Vector3(allowedScreenArea.xMax, allowedScreenArea.yMax, mainCamera.nearClipPlane + 1));
        Vector3 bottomRight = mainCamera.ScreenToWorldPoint(new Vector3(allowedScreenArea.xMax, allowedScreenArea.yMin, mainCamera.nearClipPlane + 1));

        // Set the LineRenderer positions (make sure to close the loop by repeating the first point)
        lineRenderer.SetPosition(0, bottomLeft);
        lineRenderer.SetPosition(1, topLeft);
        lineRenderer.SetPosition(2, topRight);
        lineRenderer.SetPosition(3, bottomRight);
        lineRenderer.SetPosition(4, bottomLeft);  // Closing the loop
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
