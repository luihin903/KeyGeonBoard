using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour {

    public void startGame() {

        Debug.Log("Game started.");
        SceneManager.LoadScene("L1");

    }

}