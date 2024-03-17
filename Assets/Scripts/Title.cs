using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using static Static;

public class Title : MonoBehaviour {

    public TMP_Text version;

    void Start() {
        version.text = "V" + Application.version;

        if (pp.getBool("initialized") == false) {

            pp.setBool("ending1", false);
            pp.setBool("ending2", false);
            pp.setBool("ending3", false);
            pp.setBool("ending4", false);

            pp.setBool("initialized", true);
        }
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