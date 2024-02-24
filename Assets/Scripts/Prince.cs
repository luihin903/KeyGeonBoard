using UnityEngine;
using UnityEngine.SceneManagement;

public class Prince : MonoBehaviour {

    public float speed = 5;
    public Rigidbody2D rb;

    public float horizontalInput;
    public float verticalInput;

    public int timer = 0;

    public GameObject upStairs;
    public GameObject downStairs;

    void Start() {
        
        rb = GetComponent<Rigidbody2D>();
        gameObject.transform.position = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), 0);

        upStairs.gameObject.SetActive(false);
        downStairs.gameObject.SetActive(false);

        switch(PlayerPrefs.GetInt("plot")) {
            case 14:
                if (PlayerPrefs.GetString("lastScene") != "Battle") {
                    PlayerPrefs.SetFloat("x", 0.32f);
                    PlayerPrefs.SetFloat("y", 0);
                }
                downStairs.gameObject.SetActive(true);
                break;
            case 23:
                if (PlayerPrefs.GetString("lastScene") != "Battle") {
                    PlayerPrefs.SetFloat("x", 13);
                    PlayerPrefs.SetFloat("y", -9.28f);
                }
                upStairs.gameObject.SetActive(true);
                upStairs.transform.position = new Vector3(0.32f, 1, 0);
                break;
            case 26:
                if (PlayerPrefs.GetString("lastScene") != "Battle") {
                    PlayerPrefs.SetFloat("x", 0.32f);
                    PlayerPrefs.SetFloat("y", 0);
                }
                upStairs.gameObject.SetActive(true);
                upStairs.transform.position = new Vector3(-7.36f, -9.28f, 0);
                break;
        }

        gameObject.transform.position = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), 0);
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
                PlayerPrefs.SetFloat("x", gameObject.transform.position.x);
                PlayerPrefs.SetFloat("y", gameObject.transform.position.y);
                PlayerPrefs.SetString("lastScene", "L1");
            }
        }
    }

    public bool isMoving() {
        return horizontalInput != 0 || verticalInput != 0;
    }

    public void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Wall")) {
            rb.velocity = Vector2.zero;
        }
        else if (collision.gameObject.CompareTag("DownStairs")) {
            PlayerPrefs.SetString("lastScene", "L1");
            SceneManager.LoadScene("Plot");
        }
        else if (collision.gameObject.CompareTag("UpStairs")) {
            PlayerPrefs.SetString("lastScene", "L1");
            SceneManager.LoadScene("Plot");
        }
    }
}
