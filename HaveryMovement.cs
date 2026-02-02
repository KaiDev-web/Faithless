using UnityEngine;
using UnityEngine.InputSystem;

public class HaveryMovementScript : MonoBehaviour
{
    public float walkSpeed = 6f;
    public float runSpeed = 10f;
    public float currentSpeed;

    private Rigidbody2D rb;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void FixedUpdate()
    {
        if(Keyboard.current.leftShiftKey.isPressed || Keyboard.current.cKey.isPressed)
        {
            currentSpeed = runSpeed;
        }
        else
        {
            currentSpeed = walkSpeed;
        }

        if(Keyboard.current.leftArrowKey.isPressed)
        {
            transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        }
        
        if(Keyboard.current.rightArrowKey.isPressed)
        {
            transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);
        }
    }
}
