using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour {

    public void startGame() {

        Debug.Log("Game started.");
        SceneManager.LoadScene("L1");

        int level = (int) (Random.value * 9) + 1;

        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("maxHp", level * 10);
        PlayerPrefs.SetInt("hp", level * 10);
        PlayerPrefs.SetInt("atk", level * 2);
        PlayerPrefs.SetInt("def", level);
        PlayerPrefs.SetInt("exp", 0);

        // PlayerPrefs.Save();
        // this.level = (int) (Random.value * 9) + 1;
        // this.maxHp = level * 10;
        // this.hp = maxHp;
        // this.atk = level * 2;
        // this.def = level;

    }

}