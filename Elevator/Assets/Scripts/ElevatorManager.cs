/*
 Elevator Dispatch System

 This manager coordinates elevator requests across multiple elevators.
 Each elevator maintains its own request queue while the manager
 determines which elevator should respond to a floor call.

 The current strategy selects the nearest elevator based on
 floor distance while ensuring independent queue handling.

 Designed for scalability so additional elevators or floors
 can be added with minimal changes.
*/

using UnityEngine;

public class ElevatorManager : MonoBehaviour
{
    [SerializeField]
    private ElevatorController[] elevators;

    // ElevatorManager is responsible for dispatching elevator requests.
    // When a floor button is pressed, this manager selects the most suitable elevator.
    // The selection strategy currently chooses the nearest elevator based on floor distance.
    public void RequestElevator(int floor)
    {
        ElevatorController bestElevator = null;
        int bestDistance = int.MaxValue;

        foreach (var elevator in elevators)
        {
            int distance = Mathf.Abs(elevator.GetCurrentFloor() - floor);

            if (distance < bestDistance)
            {
                bestDistance = distance;
                bestElevator = elevator;
            }
        }

        bestElevator.AddRequest(floor);
    }
}