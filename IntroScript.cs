using UnityEngine;
using TMPro;
using UnityEngine.UI; 
using System.Collections;

public class Intro_Script : MonoBehaviour
{
    public TextMeshProUGUI firstText;
    public TextMeshProUGUI secondText;
    public TextMeshProUGUI thirdText;
    public Image Backscreen; 
    public float waitTime = 4f;

    void Start()
    {

        firstText.gameObject.SetActive(false);
        secondText.gameObject.SetActive(false);
        thirdText.gameObject.SetActive(false);
   
        StartCoroutine(SequenzaIntro());
    }

    IEnumerator SequenzaIntro()
    {
        
        firstText.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        firstText.gameObject.SetActive(false);


        secondText.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        secondText.gameObject.SetActive(false);

    
        thirdText.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        thirdText.gameObject.SetActive(false);


        if(Backscreen != null) {
            Backscreen.gameObject.SetActive(false);
        }
    }
}
