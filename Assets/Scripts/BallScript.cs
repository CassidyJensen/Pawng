using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float ballSpeed;
    public float maxSpeed;
    public float minSpeed;

    private int[] dirOptions = { -1, 1 };
    private int hDir, vDir;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       // StartCoroutine("Launch"); //Start launch
        StartCoroutine(Launch());
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x > maxSpeed)
        {
            //set to max spped
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }
        if (rb.velocity.y > maxSpeed)
        {
            // set to max speed
            rb.velocity = new Vector2(rb.velocity.x, maxSpeed);
        }
    }

    // start ball moving
    public IEnumerator Launch()
    {
        yield return new WaitForSeconds(1.5f);

        // figure out directions
    
        hDir = dirOptions[Random.Range(0, dirOptions.Length)];
        vDir = dirOptions[Random.Range(0, dirOptions.Length)];

        // add a horizontal force
        rb.AddForce(transform.right * ballSpeed * hDir); // Vector2 1, 0

        // add a vertical force
        rb.AddForce(transform.up * ballSpeed * vDir); // Vector2 0,1
    }

    public void Reset()
    {
        transform.position = new Vector2(0, 0);
        rb.velocity = Vector2.zero;
        StartCoroutine(Launch());
    }

    // if out of bounds 
    private void OnCollisionEnter2D(Collision2D other)
    {
        // if wall
        if (other.gameObject.tag == "LeftBounds")
        {
            // Point for right
            ScoreScript.S.UpdateScore(1);
            //Reset the ball
            Reset();
        }
        else if (other.gameObject.tag == "RightBounds")
        {
            // point for left
            ScoreScript.S.UpdateScore(0);
            //Reset the ball
            Reset();
        }
    }
    // reset ball to middle
}
