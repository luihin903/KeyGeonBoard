using UnityEngine;
using TMPro;

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

        InvokeRepeating("attack", 5/enemy.speed, 5/enemy.speed);

        input.onEndEdit.AddListener(submit);
        input.Select();
    }

    void Update() {

        // input.Select();

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
            prince.exp += enemy.level;
            Debug.Log(prince.exp);
            prince.save();
        }

        dummy.Select();
        input.text = "";
        input.Select();
    }

    void attack() {
        prince.hp -= enemy.atk - prince.def;
    }

}