using UnityEngine;

public class Self {

    public int level;
    public int maxHp;
    public int hp;
    public int atk;
    public int def;
    public int exp;

    public Self() {
        read();
    }

    public void read() {

        level = PlayerPrefs.GetInt("level");
        maxHp = PlayerPrefs.GetInt("maxHp");
        hp = PlayerPrefs.GetInt("hp");
        atk = PlayerPrefs.GetInt("atk");
        def = PlayerPrefs.GetInt("def");
        exp = PlayerPrefs.GetInt("exp");

    }

    public void save() {

        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("maxHp", maxHp);
        PlayerPrefs.SetInt("hp", hp);
        PlayerPrefs.SetInt("atk", atk);
        PlayerPrefs.SetInt("def", def);
        PlayerPrefs.SetInt("exp", exp);

    }

    public void attack(Enemy e) {
        e.hp -= this.atk - e.def;
    }

}