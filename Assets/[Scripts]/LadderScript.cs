using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LadderScript : MonoBehaviour
{
    public int destination;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(destination, LoadSceneMode.Single);
        Debug.Log("Colliding");
    }
}
