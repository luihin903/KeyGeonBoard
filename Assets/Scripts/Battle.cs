using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Static;

public class Battle : MonoBehaviour {

    public Enemy enemy;
    public Self prince;

    public GameObject background;

    public TMP_Text enemyLevel;
    public Slider enemyHp;
    public TMP_Text princeHpText;
    public Slider princeHp;

    public TMP_Text damageByPrinceText;
    public TMP_Text damageByEnemyText;

    public Damage dp;
    public Damage de;

    public TMP_InputField input;
    public TMP_InputField dummy;

    private AudioSource hit;

    void Start() {
        PlayerPrefs.SetInt("firstWorld", 0);
        
        enemy = new Enemy();
        prince = new Self();

        if (prince.level == 1) {
            background.gameObject.SetActive(true);
        }
        else {
            background.gameObject.SetActive(false);
        }

        if (pp.getBool("freezing") == false) {
            InvokeRepeating("attackPrince", 5/enemy.speed, 5/enemy.speed);
        }

        enemyHp.maxValue = enemy.maxHp;
        princeHp.maxValue = prince.maxHp;

        input.onEndEdit.AddListener(submit);
        input.Select();

        hit = GetComponent<AudioSource>();
    
    }

    void Update() {

        enemyLevel.text = "Lv. " + enemy.level;
        princeHpText.text = prince.hp + " / " + prince.maxHp;

        enemyHp.value = enemy.hp;
        princeHp.value = prince.hp;

        if (dp != null) dp.update();
        if (de != null) de.update();
    }

    void submit(string action) {
        if (enemy.hp <= 0) return;
        
        switch (action) {
            case "attack":
                int damage = prince.attack(enemy);
                dp = new Damage(damageByPrinceText, damage, new Vector2(200, 200));
                hit.Play();
                if (pp.getBool("freezing") == true) {
                    InvokeRepeating("attackPrince", 1, 5/enemy.speed);
                    pp.setBool("freezing", false);
                }
                break;
            case "run":
                if (PlayerPrefs.GetInt("critical") == 1) {
                    Debug.Log("Critical Battle is not allowed to run");
                    break;
                }
                prince.save();
                string last = PlayerPrefs.GetString("lastScene");
                
                PlayerPrefs.SetString("lastScene", "Battle");
                SceneManager.LoadScene(last);
                break;
            case "potion":
                int potion = pp.getInt("potion");
                if (potion >= 1) {
                    prince.hp = prince.maxHp;
                    pp.setInt("potion", potion - 1);
                }
                break;
            // Cheat Code/Command
            case "iat312 exit":
                PlayerPrefs.DeleteAll();
                PlayerPrefs.Save();
                Application.Quit();
                break;
            case "iat312 levelup":
                prince.level ++;
                prince.atk += 2;
                prince.def ++;
                pp.setInt("level", prince.level);
                pp.setInt("atk", prince.atk);
                pp.setInt("def", prince.def);
                break;
        }
        
        dummy.Select();
        input.text = "";
        input.Select();

        if (enemy.hp <= 0) {
            victory();
        }
    }

    void victory() {
        
        prince.exp += enemy.level * 3 + 4;
        if (prince.level == 1) {
            prince.exp = 10;
        }
        while (prince.exp >= prince.level * 10) {
            prince.exp -= prince.level * 10;
            prince.level ++;
            prince.maxHp = prince.level * 10;
            prince.hp = prince.maxHp;
            prince.atk = prince.level * 2;
            prince.def = prince.level;
        }
        prince.save();
        string last = PlayerPrefs.GetString("lastScene");
        
        PlayerPrefs.SetString("lastScene", "Battle");
        SceneManager.LoadScene(last);
    }

    public void attackPrince() {
        int damage = enemy.attack(prince);
        de = new Damage(damageByEnemyText, damage, new Vector2(400, -200));
        hit.Play();
        if (prince.hp <= 0) {
            SceneManager.LoadScene("Dead");
        }
    }

}