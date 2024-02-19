using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Battle : MonoBehaviour {

    public Enemy enemy;
    public Self prince;
    public TextMeshProUGUI enemyLevel;
    public TextMeshProUGUI enemyHp;
    public TextMeshProUGUI princeLevel;
    public TextMeshProUGUI princeHp;
    public TMP_InputField input;
    public TMP_InputField dummy;

    void Start() {
        enemy = new Enemy();
        prince = new Self();

        InvokeRepeating("attackPrince", 5/enemy.speed, 5/enemy.speed);

        input.onEndEdit.AddListener(submit);
        input.Select();
    }

    void Update() {

        enemyLevel.text = "Enemy Level: " + enemy.level;
        enemyHp.text = "Enemy HP: " + enemy.hp;
        princeLevel.text = "Prince Level: " + prince.level;
        princeHp.text = "Prince HP: " + prince.hp;
    
    }

    void submit(string action) {
        Debug.Log(action);

        switch (action) {
            case "attack":
                prince.attack(enemy);
                break;
        }

        if (enemy.hp <= 0) {
            victory();
        }

        dummy.Select();
        input.text = "";
        input.Select();
    }

    void victory() {
        prince.exp += enemy.level * 2 + 5;
        while (prince.exp >= prince.level * 10) {
            prince.exp -= prince.level * 10;
            prince.level ++;
            prince.maxHp = prince.level * 10;
            prince.hp = prince.maxHp;
            prince.atk = prince.level * 2;
            prince.def = prince.level;
        }
        prince.save();
        SceneManager.LoadScene("L1");
    }

    public void attackPrince() {
        enemy.attack(prince);
    }

}