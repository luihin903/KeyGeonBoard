using UnityEngine;
using TMPro;

public class General : MonoBehaviour {

    public int level;
    public int maxHp;
    public int hp;
    public int atk;
    public int def;
    public int exp;

    void Update() {
        level = PlayerPrefs.GetInt("level");
        maxHp = PlayerPrefs.GetInt("maxHp");
        hp = PlayerPrefs.GetInt("hp");
        atk = PlayerPrefs.GetInt("atk");
        def = PlayerPrefs.GetInt("def");
        exp = PlayerPrefs.GetInt("exp");
    }

}