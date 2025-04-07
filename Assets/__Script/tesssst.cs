using UnityEngine;

public class TriggerDebug : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger ENTER with: " + other.name);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Trigger STAY with: " + other.name);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger EXIT with: " + other.name);
    }
}
