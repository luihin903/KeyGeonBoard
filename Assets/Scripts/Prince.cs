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

    private AudioSource walk;

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

        walk = GetComponent<AudioSource>();
    }

    void Update() {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;
        rb.velocity = movement * speed;

        if (isMoving()) {
            if (!walk.isPlaying) walk.Play();
            timer ++;
            if (Random.value - timer/500 < 0.001) {
                SceneTransition.move = true;
                PlayerPrefs.SetFloat("x", gameObject.transform.position.x);
                PlayerPrefs.SetFloat("y", gameObject.transform.position.y);
                
                switch (PlayerPrefs.GetInt("dungeonLevel")) {
                    case 1:
                        PlayerPrefs.SetString("lastScene", "L1");
                        break;
                    case 2:
                        PlayerPrefs.SetString("lastScene", "L2");
                        break;
                    case 3:
                        PlayerPrefs.SetString("lastScene", "L3");
                        break;
                }
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
            
            switch (PlayerPrefs.GetInt("dungeonLevel")) {
                case 1:
                    PlayerPrefs.SetString("lastScene", "L1");
                    PlayerPrefs.SetInt("dungeonLevel", 2);
                    SceneManager.LoadScene("L2");
                    break;
                case 2:
                    PlayerPrefs.SetString("lastScene", "L2");
                    PlayerPrefs.SetInt("dungeonLevel", 2);
                    SceneManager.LoadScene("Plot");
                    break;
            }
            
        }
        else if (collision.gameObject.CompareTag("UpStairs")) {
            
            switch (PlayerPrefs.GetInt("dungeonLevel")) {
                case 1:
                    PlayerPrefs.SetString("lastScene", "L1");
                    PlayerPrefs.SetInt("dungeonLevel", 1);
                    SceneManager.LoadScene("Plot");
                    break;
                case 2:
                    PlayerPrefs.SetString("lastScene", "L2");
                    PlayerPrefs.SetInt("dungeonLevel", 1);
                    SceneManager.LoadScene("L1");
                    break;
            }
        }
    }
}
