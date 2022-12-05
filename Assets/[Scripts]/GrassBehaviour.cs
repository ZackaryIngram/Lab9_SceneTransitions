using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            CheckForEncounters();
            Debug.Log("Touching Grass");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lemon")
        {
            CheckForEncounters();
            //Debug.Log("Touching Grass");
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
