using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Act0 : MonoBehaviour {
    
    public TextMeshProUGUI story;

    public int plot = 0;
    
    public Button choice1;
    public Button choice2;
    public Button title;

    public TextMeshProUGUI t1;
    public TextMeshProUGUI t2;
    public TextMeshProUGUI enter;

    public string[] plots = {
        "You are the prince of Ahpla Kingdom, and today is your birthday to turn 18.",
        "Your father (the king of Ahpla Kingdom): Hey son, I need you to marry the princess of Ateb Kingdom.",
        "King: Get out of my country then.",
        "You left Ahpla Kingdom and got on the way to Ateb Kingdom.",
        "You are kicked out from the country and no longer a prince.",
        "You met a monster during the trip.",
        "Tutorial"};

    void Start() {
        setP(0);
        choice1.gameObject.SetActive(false);
        choice2.gameObject.SetActive(false);
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.Return)) {
            
            switch (getP()) {
                case 0:
                    setP(1);
                    show();
                    t1.text = "\"Sure, dad.\"";
                    t2.text = "\"No way, I am not marrying someone I don\'t love.\"";
                    break;
                case 1:
                    break;
                case 3:
                    setP(5);
                    break;
                case 5:
                    setP(6);
                    PlayerPrefs.SetString("last", "Plot");
                    SceneManager.LoadScene("Battle");
                    break;
            }

        }

        story.text = plots[PlayerPrefs.GetInt("plot")];
    }

    private int getP() {
        plot = PlayerPrefs.GetInt("plot");
        return plot;
    }

    private void setP(int p) {
        PlayerPrefs.SetInt("plot", p);
        getP();
    }

    public void Choice1() {
        
        hide();

        switch (getP()) {
            case 1:
                setP(3);
                break;
            case 2:
                setP(3);
                break;
        }

    }

    public void Choice2() {
        
        hide();

        switch(getP()) {
            case 1:
                setP(2);
                show();
                t1.text = "\"Sorry dad, I will marry the princess.\"";
                t2.text = "Leave";
                break;
            case 2:
                setP(4);
                title.gameObject.SetActive(true);
                break;
        }

    }

    public void Title() {
        SceneManager.LoadScene("Title");
    }

    private void show() {
        choice1.gameObject.SetActive(true);
        choice2.gameObject.SetActive(true);
        enter.gameObject.SetActive(false);
    }

    private void hide() {
        choice1.gameObject.SetActive(false);
        choice2.gameObject.SetActive(false);
        enter.gameObject.SetActive(true);
    }

}
