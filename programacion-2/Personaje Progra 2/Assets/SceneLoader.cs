using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;
    [SerializeField]
    private float transitionTime = 1f;
    [SerializeField]
    private string sceneName = "Town";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(LoadLevel(sceneName));
        }
    }
    IEnumerator LoadLevel(string SceneName)
    {
        //play animation
        transition.SetTrigger("Start");

        //wait for animation
        yield return new WaitForSeconds(transitionTime);

        //load scene    
        SceneManager.LoadScene(SceneName);
    }
}
