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

        pp.setInt("level", level);
        pp.setInt("maxHp", level * 10 * 2);
        pp.setInt("hp", level * 10 * 2);
        pp.setInt("atk", level * 2 * 2);
        pp.setInt("def", level);
        pp.setInt("exp", 0);

        pp.setInt("plot", 0);
        PlayerPrefs.SetString("lastScene", "Title");

        pp.setInt("critical", 1);
        pp.setInt("dungeonLevel", 1);

        PlayerPrefs.SetFloat("x", -4);
        PlayerPrefs.SetFloat("y", 0);

        pp.setBool("freezing", true);
        pp.setInt("potion", 5);

        pp.setBool("Chest 1", true);
        pp.setBool("Chest 2", true);
        pp.setBool("Chest 3", true);
        pp.setBool("Chest 4", true);

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