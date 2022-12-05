using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrassBehaviour : MonoBehaviour
{
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
        if (collision.gameObject.tag == "Lemon")
        {
            SceneManager.LoadScene("BattleScene");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lemon")
        {
            SceneManager.LoadScene("BattleScene");
        }
    }
    private void CheckForEncounters()
    {
        if (Random.Range(1, 101) <= 10)
        {
            Debug.Log("Encountered an enemy");
        }
    }
}
