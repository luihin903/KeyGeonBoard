using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Act0 : MonoBehaviour {
    
    public TextMeshProUGUI story;

    public int plot = 0;

    public Button choice1;
    public Button choice2;

    public string[] plots = {
        "You are the prince of Ahpla Kingdom, and today is your birthday to turn 18.",
        "Your father (the king of Ahpla Kingdom): Hey son, I need you to marry the princess of Ateb Kingdom.",
        "You: Sure, dad.",
        "You: No way, I am not marrying someone I don't love.",
        "King: Get out of my country then.",
        "You: Sorry dad, I will marry the princess.",
        "You are kicked out from the country and no longer a prince.",
        "You left Ahpla Kingdom and got on the way to Ateb Kingdom.",
        "You met a monster during the trip.",
        "Tutorial"};

    void Start() {
        setP(0);
        choice1.gameObject.SetActive(false);
        choice2.gameObject.SetActive(false);
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.Return)) {
            
            switch (plot) {
                case 0:
                    setP(1);
                    choice1.gameObject.SetActive(true);
                    choice2.gameObject.SetActive(true);
                    break;
                case 1:
                    break;
            }

        }

        story.text = plots[PlayerPrefs.GetInt("plot")];
    }

    public int getP() {
        plot = PlayerPrefs.GetInt("plot");
        return plot;
    }

    public void setP(int p) {
        PlayerPrefs.SetInt("plot", p);
        getP();
    }

    public void Choice1() {
        Debug.Log("c1");
    }

    public void Choice2() {
        Debug.Log("c2");
    }

}
