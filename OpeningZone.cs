using UnityEngine;

public class Opening_Zone : MonoBehaviour
{
    public string openingPhrase;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Opening"))
        {
            Debug.Log("Welcome player to: " + openingPhrase);
        }
    }
}
