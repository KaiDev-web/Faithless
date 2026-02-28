using UnityEngine;
using UnityEngine.Timeline;
using TMPro;

public class Checkpoint_System : MonoBehaviour
{
    public string keyX = "SavepointX";
    public string keyY = "SavepointY";
    public float textWaitTime = 1f;
    public TextMeshProUGUI savedPositionTxt;

    void Start()
    {
        savedPositionTxt.gameObject.SetActive(false);

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
            StopAllCoroutines();
            
            StartCoroutine(ShowSaveText());
        }      
    }

    IEnumerator ShowSaveText()
    {
        savedPositionTxt.gameObject.SetActive(true);
        yield return new WaitForSeconds(textWaitTime);
        savedPositionTxt.gameObject.SetActive(false);
    }
}
