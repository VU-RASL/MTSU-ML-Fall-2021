using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    // public Animator transition;
    // public float transitionTime = 1f;

     public void Update()
    {
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
        StartCoroutine(LoadScene(0));
        }
        else
        {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    IEnumerator LoadScene(int levelIndex)
    {
        // transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);
        
        SceneManager.LoadScene(levelIndex);

    }
}
