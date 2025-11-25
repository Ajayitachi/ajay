using UnityEngine;
using UnityEngine.SceneManagement;

public class Drag : MonoBehaviour
{
    // Private variables
    private bool isDragging = false;
    private Camera mainCamera;
    private Vector3 offset;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        // Assign the main camera
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { 
            Debug.Log("mouse buttotn is clicked"); 
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            Collider2D collider = Physics2D.OverlapPoint(mousePosition);
            if (collider != null && collider.gameObject == gameObject)  
            {
                
            }
        } 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
            Debug.Log("Grounded = ture");
        }
        
        //if (collision.gameObject.name == "Capsule")
        //{
        //    Debug.Log("Collided with Capsule!");
        //}

        if (collision.gameObject.layer == LayerMask.NameToLayer("Capsule"))
        {
            isGrounded = true;
            Debug.Log("Grounded = ture");
            Scenemanager();
        }

    }
    void Scenemanager()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
