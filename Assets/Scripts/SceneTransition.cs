using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

    public static bool move = false;

    public RectTransform rt;

    public Vector2 initialPosition;

    void Start() {
        rt = GetComponent<RectTransform>();
        initialPosition = rt.anchoredPosition;
    }

    void Update() {
        Vector2 target = new Vector2(0, 0);
        if (move) {
            rt.anchoredPosition = Vector2.MoveTowards(rt.anchoredPosition, target, 20);
            if (Vector2.Distance(rt.anchoredPosition, target) <= Vector2.Distance(initialPosition, target) / 2) {
                move = false;
                SceneManager.LoadScene("Battle");
            }
        }
    }

}