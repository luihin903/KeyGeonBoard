using UnityEngine;
using UnityEngine.SceneManagement;

public class Prince : MonoBehaviour {

    public int level;
    public string last;
    public int plot;

    public float speed = 5;
    public Rigidbody2D rb;
    public bool walkable = true;

    public float horizontalInput;
    public float verticalInput;

    public int timer = 0;
    private bool loading = false;

    public GameObject upStairs;
    public GameObject downStairs;

    private AudioSource walk;

    void Start() {
        level = PlayerPrefs.GetInt("dungeonLevel");
        last = PlayerPrefs.GetString("lastScene");
        plot = PlayerPrefs.GetInt("plot");

        rb = GetComponent<Rigidbody2D>();
        gameObject.transform.position = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), 0);
        walkable = true;

        show(upStairs);
        show(downStairs);

        switch(level) {
            case 1:
                if (last == "L2") setPos(12.80f, -9.28f);
                else if (last == "Plot") setPos(0.32f, 0);
                
                if (plot == 14) hide(upStairs);
                else if (plot == 23) upStairs.transform.position = new Vector3(0.32f, 1, 0);
                else if (plot == 26) upStairs.transform.position = new Vector3(-7.36f, -9.28f, 0);
                
                break;
            case 2:
                if (last == "L1") setPos(0.32f, 0);
                else if (last == "Plot") setPos(-2.56f, -12.80f);
                
                if (plot != 14) hide(downStairs);
                break;
            case 3:
                break;
        }     

        gameObject.transform.position = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), 0);

        walk = GetComponent<AudioSource>();
    }

    void Update() { if (loading) return;
        
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;
        if (!walkable) movement = new Vector2(0, 0);
        rb.velocity = movement * speed;

        if (isMoving()) {
            if (!walk.isPlaying) walk.Play();
            timer ++;
            if (Random.value - timer/500 < 0.001) {
                walkable = false;
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

    public void OnCollisionStay2D(Collision2D collision) { if (loading) return;
        if (collision.gameObject.CompareTag("Wall")) {
            rb.velocity = Vector2.zero;
        }
        else if (collision.gameObject.CompareTag("DownStairs")) {
            
            switch (level) {
                case 1:
                    PlayerPrefs.SetString("lastScene", "L1");
                    PlayerPrefs.SetInt("dungeonLevel", 2);
                    Debug.Log("L1 -> L2 (Down)");
                    loading = true;
                    SceneManager.LoadScene("L2");
                    break;
                case 2:
                    PlayerPrefs.SetString("lastScene", "L2");
                    PlayerPrefs.SetInt("dungeonLevel", 2);
                    Debug.Log("L2 -> Plot (Down)");
                    loading = true;
                    SceneManager.LoadScene("Plot");
                    break;
            }
            
        }
        else if (collision.gameObject.CompareTag("UpStairs")) {
            
            switch (PlayerPrefs.GetInt("dungeonLevel")) {
                case 1:
                    PlayerPrefs.SetString("lastScene", "L1");
                    PlayerPrefs.SetInt("dungeonLevel", 1);
                    Debug.Log("L1 -> Plot (Up)");
                    loading = true;
                    SceneManager.LoadScene("Plot");
                    break;
                case 2:
                    PlayerPrefs.SetString("lastScene", "L2");
                    PlayerPrefs.SetInt("dungeonLevel", 1);
                    Debug.Log("L2 -> L1 (Up)");
                    loading = true;
                    SceneManager.LoadScene("L1");
                    Debug.Log("aaa");
                    break;
            }
        }
    }

    private void setPos(float x, float y) {
        PlayerPrefs.SetFloat("x", x);
        PlayerPrefs.SetFloat("y", y);
    }

    // private void show(string target) {
    //     switch (target) {
    //         case "up":
    //             upStairs.gameObject.SetActive(true);
    //             break;
    //         case "down":
    //             downStairs.gameObject.SetActive(true);
    //             break;
    //     }
    // }

    // private void hide(string target) {
    //     switch (target) {
    //         case "up":
    //             upStairs.gameObject.SetActive(false);
    //             break;
    //         case "down":
    //             downStairs.gameObject.SetActive(false);
    //             break;
    //     }
    // }

    private void show(GameObject target) {
        target.gameObject.SetActive(true);
    }

    private void hide(GameObject target) {
        target.gameObject.SetActive(false);
    }
}
