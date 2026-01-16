using UnityEngine;

public class Spikes : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            Debug.Log("Enter player collison with: " + collision.collider.name);
            collision.collider.GetComponent<PlayerHealth>().Die();
        }
    }
}
