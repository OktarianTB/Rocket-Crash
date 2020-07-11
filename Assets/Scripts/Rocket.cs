using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField()]
    float speed = 120;

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool makeFly = true;
    public bool gameFinished = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!rb)
        {
            print("Missing RB component from Rocket");
        }
    }
    
    void Update()
    {
        Vector2 directions = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movement = directions.normalized * speed * Random.Range(0.8f, 1.2f);
        movement.x *= Random.Range(0.3f, 0.6f);
    }

    private void FixedUpdate()
    {
        if (makeFly && !gameFinished)
        {
            rb.AddRelativeForce(movement, ForceMode2D.Force);
            makeFly = false;
            StartCoroutine(Timer(0.1f));
        }
    }

    IEnumerator Timer(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        makeFly = true;
    }

}
