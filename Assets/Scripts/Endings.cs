using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using static Static;

public class Endings : MonoBehaviour {

    public TMP_Text t1;
    public TMP_Text t2;
    public TMP_Text t3;
    public TMP_Text t4;

    void Start() {
        if (pp.getBool("ending1") == false) {
            t1.text = "1. Locked";
        }
        if (pp.getBool("ending2") == false) {
            t2.text = "2. Locked";
        }
        if (pp.getBool("ending3") == false) {
            t3.text = "3. Locked";
        }
        if (pp.getBool("ending4") == false) {
            t4.text = "4. Locked";
        }
    }

    public void Title() {
        SceneManager.LoadScene("Title");
    }
}