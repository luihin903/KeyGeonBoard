using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class General : MonoBehaviour {

    public int level;
    public int maxHp;
    public int hp;
    public int atk;
    public int def;
    public int exp;
    public string lastScene;
    public Vector3 pos;
    public int plot;

    void Update() {
        level = PlayerPrefs.GetInt("level");
        maxHp = PlayerPrefs.GetInt("maxHp");
        hp = PlayerPrefs.GetInt("hp");
        atk = PlayerPrefs.GetInt("atk");
        def = PlayerPrefs.GetInt("def");
        exp = PlayerPrefs.GetInt("exp");
        lastScene = PlayerPrefs.GetString("lastScene");
        pos = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), 0);
        plot = PlayerPrefs.GetInt("plot");
    }

    public void BackToTitle() {
        SceneManager.LoadScene("Title");
    }

}