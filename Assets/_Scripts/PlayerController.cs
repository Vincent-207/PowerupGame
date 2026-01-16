using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed, maxSpeed;
    public InputActionReference move;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector2 moveInput = move.action.ReadValue<Vector2>();
        moveInput.y = 0;
        if(rb.linearVelocity.magnitude < maxSpeed)
        {
            rb.AddForce(moveInput * moveSpeed * Time.fixedDeltaTime);
            
        }
        
    }
}
