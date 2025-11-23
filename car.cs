using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SimpleCarController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 100f;

    public int score = 0;
    public TMP_Text scoreText;  // UI Text reference

    void Start()
    {
        scoreText.text = "Score: " + score;
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * moveInput * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * turnInput * turnSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PointObject"))
        {
            score++;
            scoreText.text = "Score: " + score;   // Update UI
            Debug.Log("Score: " + score);
        }
    }
}
