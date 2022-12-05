using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator fadeTransition;

    public float transitionTime = 1.0f;

    // Update is called once per frame
    void Update()
    {
        //Testing 
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    LoadNextLevel();
        //}
    }

    public void LoadNextLevel()
    {
        StartCoroutine(TransitionCoroutine(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator TransitionCoroutine(int levelIndex)
    {
        fadeTransition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }


}
