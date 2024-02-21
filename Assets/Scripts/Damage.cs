using UnityEngine;
using TMPro;

public class Damage {

    public TMP_Text t;
    public RectTransform rt;
    public float counter;
    public Vector2 pos;

    public Damage(TMP_Text t, int d, Vector2 pos) {
        this.pos = pos;
        this.t = t;
        t.gameObject.SetActive(true);
        rt = t.GetComponent<RectTransform>();
        t.text = "-" + d;
        rt.anchoredPosition = pos;
        counter = -100;
    }

    public void update() {
        counter += 4f;
        rt.anchoredPosition = pos + new Vector2(counter, -counter*counter/100);
        if (counter >= 100) {
            t.gameObject.SetActive(false);
        }
    }

}