using UnityEngine;
using TMPro;

public class Battle : MonoBehaviour {

    public Enemy enemy;
    public TextMeshProUGUI level;
    public TextMeshProUGUI hp;

    void Start() {
        enemy = new Enemy();
        level.text = "Level: " + enemy.level;
        hp.text = "Hp: " + enemy.hp;
    }

}