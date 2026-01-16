using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class LazerGun : MonoBehaviour
{
    public float turnSpeed;

    [Header("Lazer settings")]
    public float maxLazerRange;
    public LayerMask lazerHitMask;
    public InputActionReference shootInput;
    // tutorial
    public Transform lasterFirePoint;
    public LineRenderer m_lineRenderer;
    [Header("Push settings")]
    public Rigidbody2D playerRB;
    public float pushForce;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TurnTowardsMouse();
// Debug.DrawRay(transform.position, transform.right * maxLazerRange, Color.red);
        if(shootInput.action.IsPressed())
        {
            Debug.Log("attackuibng!");
            Shoot();
        }
    }

    void TurnTowardsMouse()
    {
        Vector3 toMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        toMouse.Normalize();  
        float rot_z = Mathf.Atan2(toMouse.y, toMouse.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0f, 0f, rot_z);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation ,turnSpeed * Time.deltaTime);
        
        
    }


    void Shoot()
    {
        // get distance to nearest
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, transform.right, maxLazerRange, lazerHitMask);

        if(raycastHit.collider != null && raycastHit.distance < maxLazerRange)
        {
            // Debug.DrawRay(transform.position, transform.right * raycastHit.distance, Color.green);
            // Debug.Log(raycastHit.collider.name);
            Draw2DRay(transform.position, raycastHit.point);
        }
        else
        {
            // Debug.DrawRay(transform.position, transform.right * maxLazerRange, Color.red);
            Draw2DRay(transform.position, transform.right * maxLazerRange);
            
        }


        playerRB.AddForce(-transform.right * pushForce * Time.deltaTime, ForceMode2D.Force);

            // Debug.Log("Couldn't find hit");
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);

    }
}
