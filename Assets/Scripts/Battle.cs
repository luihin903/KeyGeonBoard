using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Battle : MonoBehaviour {

    public Enemy enemy;
    public Self prince;

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

    void Start() {
        enemy = new Enemy();
        prince = new Self();

        enemyHp.maxValue = enemy.maxHp;
        princeHp.maxValue = prince.maxHp;

        InvokeRepeating("attackPrince", 5/enemy.speed, 5/enemy.speed);

        input.onEndEdit.AddListener(submit);
        input.Select();
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

        switch (action) {
            case "attack":
                int damage = prince.attack(enemy);
                dp = new Damage(damageByPrinceText, damage, new Vector2(200, 200));
                break;
            case "run":
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
        SceneManager.LoadScene("L1");
    }

    public void attackPrince() {
        int damage = enemy.attack(prince);
        de = new Damage(damageByEnemyText, damage, new Vector2(400, -200));
    }

}