using UnityEngine;
using UnityEngine.SceneManagement;

public class Prince : MonoBehaviour {
    
    public float speed = 5;
    public Rigidbody2D rb;

    public float horizontalInput;
    public float verticalInput;

    public int timer = 0;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;
        rb.velocity = movement * speed;

        if (isMoving()) {
            timer ++;
            if (Random.value - timer/500 < 0.001) {
                SceneManager.LoadScene("Battle");
            }
        }
    }

    public bool isMoving() {
        return horizontalInput != 0 || verticalInput != 0;
    }
}
