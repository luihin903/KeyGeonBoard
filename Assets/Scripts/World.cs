using UnityEngine;
using UnityEngine.SceneManagement;

public class World : MonoBehaviour {

    public float speed = 5f;
    public Rigidbody2D rb;
    public bool walkable = true;
    public float horizontalInput;
    public float verticalInput;
    private AudioSource walk;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log(PlayerPrefs.GetFloat("x"));
        Debug.Log(PlayerPrefs.GetFloat("y"));
        gameObject.transform.position = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), 0);
        walkable = true;
        walk = GetComponent<AudioSource>();
        
    }
    
    void Update() {
        
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;
        if (!walkable) movement = new Vector2(0, 0);
        rb.velocity = movement * speed;

        if (isMoving()) {
            if (!walk.isPlaying) walk.Play();
            if (gameObject.transform.position.x >= 0 && PlayerPrefs.GetInt("firstWorld") == 1) {
                walkable = false;
                SceneTransition.move = true;
                PlayerPrefs.SetFloat("x", gameObject.transform.position.x);
                PlayerPrefs.SetFloat("y", gameObject.transform.position.y);
                PlayerPrefs.SetString("lastScene", "World");

            }
        }
        
    }

    private bool isMoving() {
        return horizontalInput != 0 || verticalInput != 0;
    }

    public void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Wall")) {
            // rb.velocity = Vector2.zero;
        }
        else if (collision.gameObject.CompareTag("Ateb")) {
            SceneManager.LoadScene("Plot");
        }
    }

}