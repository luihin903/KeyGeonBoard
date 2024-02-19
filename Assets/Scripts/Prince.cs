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
        PlayerPrefs.SetFloat("x", -0.32f);
        PlayerPrefs.SetFloat("y", 0);
    }

    void Update() {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;
        rb.velocity = movement * speed;

        if (isMoving()) {
            timer ++;
            if (Random.value - timer/500 < 0.001) {
                SceneTransition.move = true;
                PlayerPrefs.SetFloat("x", transform.position.x);
                PlayerPrefs.SetFloat("y", transform.position.y);
            }
        }
    }

    void Awake() {
        transform.position = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), 0);
    }

    public bool isMoving() {
        return horizontalInput != 0 || verticalInput != 0;
    }

    public void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Wall")) {
            rb.velocity = Vector2.zero;
        }
        else if (collision.gameObject.CompareTag("DownStairs")) {
            SceneManager.LoadScene("L2");
        }
    }
}
