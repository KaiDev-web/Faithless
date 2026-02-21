using UnityEngine;
using UnityEngine.InputSystem;

public class HaveryMovemetScript : MonoBehaviour
{
    public float walkSpeed = 6f;
    public float runSpeed = 10f;
    public float currentSpeed;
    public float direction;
    public bool isGrounded;
    public bool isRunning;
    public Animator anim;

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
            Flip(false);
        }
        
        if(Keyboard.current.rightArrowKey.isPressed)
        {
            transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);
            Flip(true); 
        }
        anim.SetBool("isGrounded", isGrounded);
        if(direction != 0)
            anim.SetBool("isRunning", true);
        else
            anim.SetBool("isRunning", false);

        anim.SetFloat("YVelocity", rb.linearVelocity.y);
    }


    void Flip(bool faceRight)
    {
        Vector3 newScale = transform.localScale;
        if (faceRight)
        {
            newScale.x = Mathf.Abs(newScale.x); 
        }
        else
        {
            newScale.x = -Mathf.Abs(newScale.x); 
        }
        transform.localScale = newScale;
    }
}
