using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Title : MonoBehaviour {

    public TMP_Text version;

    void Start() {
        version.text = "V" + Application.version;
    }

    public void StartGame() {

        int level = 1;

        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("maxHp", level * 10 * 2);
        PlayerPrefs.SetInt("hp", level * 10 * 2);
        PlayerPrefs.SetInt("atk", level * 2 * 2);
        PlayerPrefs.SetInt("def", level);
        PlayerPrefs.SetInt("exp", 0);

        PlayerPrefs.SetInt("plot", 0);
        PlayerPrefs.SetString("lastScene", "Title");

        PlayerPrefs.SetInt("critical", 1);
        PlayerPrefs.SetInt("dungeonLevel", 1);

        PlayerPrefs.SetFloat("x", -4);
        PlayerPrefs.SetFloat("y", 0);

        SceneManager.LoadScene("Plot");

    }

    public void Endings() {
        PlayerPrefs.SetString("lastScene", "Title");
        SceneManager.LoadScene("Endings");
    }

    public void Exit() {
        Application.Quit();
    }

}