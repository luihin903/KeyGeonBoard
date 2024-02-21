using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour {

    public void startGame() {

        SceneManager.LoadScene("Plot");

        int level = 1;

        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("maxHp", level * 10);
        PlayerPrefs.SetInt("hp", level * 10);
        PlayerPrefs.SetInt("atk", level * 2);
        PlayerPrefs.SetInt("def", level);
        PlayerPrefs.SetInt("exp", 0);

    }

}