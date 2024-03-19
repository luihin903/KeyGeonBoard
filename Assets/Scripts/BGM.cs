using UnityEngine;

public class BGM : MonoBehaviour {
    void Start() {
        DontDestroyOnLoad(gameObject);
    }
}