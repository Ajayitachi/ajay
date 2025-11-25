using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jump : MonoBehaviour
{
    public float jumpForce = 5f; // Set in Inspector
    private Rigidbody2D rb;
    public float movementspeed = 5f;
    private bool isGrounded;
    public int score = 0;
    public bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get Rigidbody2D attached to GameObject
    }

    void Update()
    {
        // Detect left mouse button click
        if (Input.GetMouseButtonDown(0) && !isJumping)

        {
            isJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movementspeed, rb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
            Debug.Log("Grounded = ture");
        }

        if (collision.gameObject.name == "Capsule")
        {
            Debug.Log("Collided with Capsule!");
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Pointscollector"))
        {
            Debug.Log("Points added");
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Pointscollector"))
        {
            score = score + 1;
            Debug.Log("Score +1");
            Destroy(collision.gameObject);
            ScoreText.instance.AddPoint();
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Landed");
            isJumping = false;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dead End"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}