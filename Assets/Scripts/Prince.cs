using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using static Static;

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

    public TMP_Text findDemon;
    public TMP_Text leave;
    public TMP_Text findAnother;

    private AudioSource walk;

    public TMP_Text notification;

    void Start() {
        level = PlayerPrefs.GetInt("dungeonLevel");
        last = PlayerPrefs.GetString("lastScene");
        plot = PlayerPrefs.GetInt("plot");

        rb = GetComponent<Rigidbody2D>();
        gameObject.transform.position = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), 0);
        walkable = true;

        show(upStairs);
        show(downStairs);

        switch (plot) {
            case 14:
                show(findDemon);
                break;
            case 23:
                show(leave);
                break;
            case 26:
                show(findAnother);
                break;
        }

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
                else if (last == "L3") setPos(-2.56f, -12.80f);
                break;
            case 3:
                if (last == "L2") setPos(9.28f, -7.04f);
                else if (last == "Plot") setPos(-6.08f, 10.24f);

                if (plot != 14) hide(downStairs);
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
                    pp.setString("lastScene", "L1");
                    pp.setInt("dungeonLevel", 2);
                    Debug.Log("L1 -> L2 (Down)");
                    loading = true;
                    SceneManager.LoadScene("L2");
                    break;
                case 2:
                    pp.setString("lastScene", "L2");
                    pp.setInt("dungeonLevel", 3);
                    Debug.Log("L2 -> L3 (Down)");
                    loading = true;
                    SceneManager.LoadScene("L3");
                    break;
                case 3:
                    pp.setString("lastScene", "L3");
                    pp.setInt("dungeonLevel", 2);
                    Debug.Log("L3 -> Plot (Down)");
                    loading = true;
                    SceneManager.LoadScene("Plot");
                    break;
            }
            
        }
        else if (collision.gameObject.CompareTag("UpStairs")) {
            
            switch (level) {
                case 1:
                    pp.setString("lastScene", "L1");
                    pp.setInt("dungeonLevel", 1);
                    Debug.Log("L1 -> Plot (Up)");
                    loading = true;
                    SceneManager.LoadScene("Plot");
                    break;
                case 2:
                    pp.setString("lastScene", "L2");
                    pp.setInt("dungeonLevel", 1);
                    Debug.Log("L2 -> L1 (Up)");
                    loading = true;
                    SceneManager.LoadScene("L1");
                    break;
                case 3:
                    pp.setString("lastScene", "L3");
                    pp.setInt("dungeonLevel", 2);
                    Debug.Log("L3 -> L2 (Up)");
                    loading = true;
                    SceneManager.LoadScene("L2");
                    break;
            }
        }
        else if (collision.gameObject.CompareTag("Chest")) {
            
            collision.gameObject.SetActive(false);
            pp.setBool(collision.gameObject.name, false);

            switch (collision.gameObject.name) {
                
                case "Chest 1":
                    int atk = pp.getInt("atk");
                    notify($"You opened a chest.\nYou found \"Monster Slayer\",\nATK = {atk} -> {atk}+5.\n(Press tab to inspect)");
                    break;
                case "Chest 2":
                    notify("You opened a chest.\nYou found \"Spell-FireLighter\".\n(Press tab to inspect)");
                    break;
                case "Chest 3":
                    notify("You opened a chest.\nIt was empty.");
                    break;
                case "Chest 4":
                    pp.setInt("potion", pp.getInt("potion") + 5);
                    notify("You opened a chest.\nYou found 5 potions.\n(Press tab to inspect)");
                    break;
            }
        }
    
    }

    private void setPos(float x, float y) {
        PlayerPrefs.SetFloat("x", x);
        PlayerPrefs.SetFloat("y", y);
    }

    private void show(GameObject target) {
        target.gameObject.SetActive(true);
    }

    private void show(TMP_Text target) {
        target.gameObject.SetActive(true);
    }

    private void hide(GameObject target) {
        target.gameObject.SetActive(false);
    }

    private void notify(string message) {
        notification.gameObject.SetActive(true);
        notification.text = message;
        StartCoroutine(disappear());
    }

    private IEnumerator disappear() {
        yield return new WaitForSeconds(4f);
        notification.gameObject.SetActive(false);
    }
}
