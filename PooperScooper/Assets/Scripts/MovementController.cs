using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed = 5f;
    public float minX, maxX, minZ, maxZ; // Boundaries for movement
    public float fixedY = 0f; // Fixed Y value

    // Start is called before the first frame update
    void Start()
    {
        fixedY = transform.position.y;
    }

    // FixedUpdate is called once per fixed frame-rate frame
    void FixedUpdate()
    {
        Vector3 targetPosition = GetCursorPosition();
        //Debug.Log("Target Position: " + targetPosition);
        MoveTowardsTarget(targetPosition);
    }

    Vector3 GetCursorPosition()
    {
        Vector3 cursorPosition = Vector3.zero;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                cursorPosition = hit.point;
                //Debug.Log("Touch Position: " + touch.position);
            }
        }
        else if (Input.mousePresent)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                cursorPosition = hit.point;
                //Debug.Log("Mouse Position: " + Input.mousePosition);
            }
        }

        cursorPosition.y = fixedY; // Ensure the target position is on the same y plane as the game object
        //Debug.Log("Cursor World Position: " + cursorPosition);
        return cursorPosition;
    }

    void MoveTowardsTarget(Vector3 targetPosition)
    {
        Vector3 currentPosition = transform.position;
        Vector3 direction = (targetPosition - currentPosition).normalized;
        Vector3 newPosition = Vector3.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);

        // Apply boundaries
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);
        newPosition.y = fixedY; // Ensure the new position is on the same y plane as the game object

        //Debug.Log("Current Position: " + currentPosition);
        //Debug.Log("New Position: " + newPosition);

        transform.position = newPosition;
    }
}
