using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public float waitTime = 3f;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    
    public TextMeshProUGUI text4;
    public Canvas background;

    private void Start()
    {
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
        text3.gameObject.SetActive(false);
        text4.gameObject.SetActive(false);

        background.gameObject.SetActive(false);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Starting Coroutine. Searching for texts");
            StartCoroutine(StartDialogue());
        }
    }

    IEnumerator StartDialogue()
    {
        Debug.Log("Starting Dialogue");

        background.gameObject.SetActive(true);
        
        text1.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        text1.gameObject.SetActive(false);
        
        text2.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        text2.gameObject.SetActive(false);
        
        text3.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        text3.gameObject.SetActive(false);
        
        text4.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        text4.gameObject.SetActive(false);

        background.gameObject.SetActive(false);
        
        Debug.Log("Ending Dialogue.");
    }
    
    
}
