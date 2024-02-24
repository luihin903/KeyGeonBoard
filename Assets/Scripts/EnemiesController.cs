using UnityEngine;

public class EnemiesController : MonoBehaviour {
    
    public GameObject slime;
    public GameObject soldier;
    public GameObject knight;

    void Start() {

        slime.gameObject.SetActive(false);
        soldier.gameObject.SetActive(false);
        knight.gameObject.SetActive(false);

        if (PlayerPrefs.GetInt("plot") == 27) {
            soldier.gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("plot") == 29) {
            knight.gameObject.SetActive(true);
        }
        else {
            slime.gameObject.SetActive(true);
        }

    }

}