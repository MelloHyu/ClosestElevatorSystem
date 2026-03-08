using UnityEngine;

public class FloorButton : MonoBehaviour
{
    [SerializeField]
    private ElevatorManager manager;

    public void PressButton(int floorNumber)
    {
        manager.RequestElevator(floorNumber);
        Debug.Log("Floor requested: " + floorNumber);
        manager.RequestElevator(floorNumber);

    }
}