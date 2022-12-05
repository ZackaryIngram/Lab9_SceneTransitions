using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    [Range(0, 5)]
    private float m_moveSpeed = 10.0f;

    private bool isMoving;
    private Vector2 input;

    public float radius = 0.01f;

    [SerializeField]
    Rigidbody2D rigidbody;

    public LayerMask grassLayer;

    public event Action OnEncountered;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void HandleUpdate()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input != Vector2.zero)
            {
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                StartCoroutine(Move(targetPos));
            }
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, m_moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
        CheckForEncounters();
    }


    private void CheckForEncounters()
    {
        if(Physics2D.OverlapCircle(transform.position, radius, grassLayer) != null)
        {
            if (UnityEngine.Random.Range(1, 101) <= 50)
            {
                OnEncountered();
            }
        }
    }
}
