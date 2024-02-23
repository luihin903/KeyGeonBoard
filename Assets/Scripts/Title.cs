using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour {

    public void startGame() {

        int level = 1;

        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("maxHp", level * 10 * 2);
        PlayerPrefs.SetInt("hp", level * 10 * 2);
        PlayerPrefs.SetInt("atk", level * 2 * 2);
        PlayerPrefs.SetInt("def", level);
        PlayerPrefs.SetInt("exp", 0);

        PlayerPrefs.SetInt("plot", 0);
        PlayerPrefs.SetString("lastScene", "Title");

        SceneManager.LoadScene("Plot");

    }

    public void Exit() {
        Application.Quit();
    }

}