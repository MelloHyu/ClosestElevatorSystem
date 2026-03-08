using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    private int currentFloor = 0;
    [SerializeField]
    private float speed = 4f;

    [SerializeField]
    private List<Transform> floorPositions;

    // Queue storing all requested floors for this elevator.
    // Each elevator maintains its own independent request queue.
    Queue<int> requestQueue = new Queue<int>();

    bool isMoving = false;
    int targetFloor;

  
    void Update()
    {
        if (isMoving)
        {
            MoveElevator();
        }
    }

    public void AddRequest(int floor)
    {
        if (!requestQueue.Contains(floor))
        {
            requestQueue.Enqueue(floor);
        }

        if (!isMoving)
            MoveToNextFloor();
    }
    // Prevent duplicate floor requests from being added to the queue.
    // This simulates real elevator button behavior.

    void MoveToNextFloor()
    {
        if (requestQueue.Count == 0)
        {
            isMoving = false;
            return;
        }

        targetFloor = requestQueue.Dequeue();
        isMoving = true;
    }

    // Moves the elevator smoothly toward the target floor position.
    // Only the Y axis is updated to ensure the elevator moves vertically.
    void MoveElevator()
    {
        Transform targetPos = floorPositions[targetFloor];

        Vector3 newPosition = transform.position;

        newPosition.y = Mathf.MoveTowards(
            transform.position.y,
            targetPos.position.y,
            speed * Time.deltaTime
        );

        transform.position = newPosition;

        if (Mathf.Abs(transform.position.y - targetPos.position.y) < 0.01f)
        {
            currentFloor = targetFloor;
            isMoving = false;

            MoveToNextFloor();
        }
    }

    public int GetCurrentFloor()
    {
        return currentFloor;
    }
}