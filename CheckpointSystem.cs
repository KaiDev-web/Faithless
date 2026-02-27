using UnityEngine;
using UnityEngine.Timeline;

public class Checkpoint_System : MonoBehaviour
{
    public string keyX = "SavepointX";
    public string keyY = "SavepointY";

    void Start()
    {
        
        float x = PlayerPrefs.GetFloat(keyX, transform.position.x);
        float y = PlayerPrefs.GetFloat(keyY, transform.position.y);
        transform.position = new Vector2(x, y);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Connettendo con TAG");
        if(collision.CompareTag("Checkpoint"))
        {
            PlayerPrefs.SetFloat(keyX, collision.transform.position.x);
            PlayerPrefs.SetFloat(keyY, collision.transform.position.y);

            PlayerPrefs.Save();

            Debug.Log("Posizione salvata:" + collision.transform.position);
        }      
    }
}
