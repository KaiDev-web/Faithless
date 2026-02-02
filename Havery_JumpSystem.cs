using UnityEngine;
using UnityEngine.InputSystem;

public class HaveryJumpSystem : MonoBehaviour
{
    public float jump;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Keyboard.current.zKey.isPressed)
        {
            rb.AddForce(new Vector2(rb.linearVelocityX, jump)); 
        }

    }

}
