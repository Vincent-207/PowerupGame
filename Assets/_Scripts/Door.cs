using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    public UnityEvent doorTriggered;
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Entered");
        if(col.CompareTag("Player"))
        {
            Debug.Log("Door is entered by player");
            doorTriggered.Invoke();
        }
    }
}
