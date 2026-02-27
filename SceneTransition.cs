using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Scene_Transition : MonoBehaviour
{
    public string nomeScenaDaCaricare;

    void Start()
    {
        if(Transition.deveTeletrasportarsi)
        {
            transform.position = Transition.posizioneDiArrivo;
            Transition.deveTeletrasportarsi = false;
        }
    }

    void OnEnterTrigger2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(nomeScenaDaCaricare);
        }  
    }
    public void TransitionStart(Vector2 nuovaPosizione, string nomeScena)
    {
        Transition.posizioneDiArrivo = nuovaPosizione;
        Transition.deveTeletrasportarsi = true;

        UnityEngine.SceneManagement.SceneManager.LoadScene(nomeScena);
    }
    
}
