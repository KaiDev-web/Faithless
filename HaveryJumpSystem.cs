using UnityEngine;
using UnityEngine.InputSystem;

public class HaveryJumpSystem : MonoBehaviour
{
    public float jumpForce = 7f;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Keyboard.current.zKey.wasPressedThisFrame)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
