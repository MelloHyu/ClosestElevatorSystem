using TMPro;
using UnityEngine;

public class ElevatorDisplay : MonoBehaviour
{
    [SerializeField]
    private ElevatorController elevator;
    [SerializeField]
    private TextMeshProUGUI text;

    void Update()
    {
        text.text = "Floor: " + elevator.GetCurrentFloor();
    }
}