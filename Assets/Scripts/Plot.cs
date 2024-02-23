using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Act0 : MonoBehaviour {
    
    public TextMeshProUGUI story;

    public int plot = 0;
    
    public Image background;

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
        "You arrived Ateb Kingdom.",
        "King: \"Welcome, you must be the prince of Ahpla Kingdom!\"",
        "King: \"You must be here to marry my lovely daughter. However, you can't marry her right now.",
        "The knight standing next to the king cut you into halves.",
        "You left Ateb Kingdom and went back to Ahpla Kingdom.",
        "King: \"One month ago, a demon brought her into the dungeon. Could you bring her back?",
        "King: \"Interesting. I am consider paying you for that.\"",
        "You bought some supplies from the store and got into the dungeon.",
        "You saw the demon.",
        "Demon: \"Don't kill me, I am the princess of Ateb Kingdom.",
        "Demon: \"My father turned me into a demon with his black magic.",
        "You killed the demon.",
        "Demon: \"Could you\""};

    void Start() {
        setP(0);
        choice1.gameObject.SetActive(false);
        choice2.gameObject.SetActive(false);

        if (PlayerPrefs.GetString("lastScene") == "Battle") {
            setP(6);
        }
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
                case 3:
                    setP(5);
                    break;
                case 5:
                    setP(6);
                    PlayerPrefs.SetString("lastScene", "Plot");
                    SceneManager.LoadScene("Battle");
                    break;
                case 6:
                    setP(7);
                    show();
                    t1.text = "\"Yes, I am.\"";
                    t2.text = "\"No, I am not.\"";
                    break;
                case 12:
                    setP(13);
                    break;
                case 13:
                    setP(14);
                    PlayerPrefs.SetString("lastScene", "Plot");
                    SceneManager.LoadScene("L1");
                    break;
                case 14:
                    setP(15);
                    show();
                    t1.text = "\"But you are obviously a demon...\"";
                    t2.text = "\"Shut up and go to hell!\"";
                    break;
                case 16:
                    setP(18);
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
                background.gameObject.SetActive(true);
                break;
            case 2:
                setP(3);
                background.gameObject.SetActive(true);
                break;
            case 7:
                setP(8);
                show();
                t1.text = "\"Okay, bye then.\"";
                t2.text = "\"Why can't I?\"";
                break;
            case 8:
                setP(10);
                background.gameObject.SetActive(true);
                title.gameObject.SetActive(true);
                break;
            case 11:
                setP(13);
                break;
            case 15:
                setP(16);
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
            case 7:
                setP(9);
                title.gameObject.SetActive(true);
                break;
            case 8:
                setP(11);
                show();
                t1.text = "\"Sure.\"";
                t2.text = "\"Dungeon? Demon? Hell no!\"" ;
                break;
            case 11:
                setP(12);
                break;
            case 15:
                setP(17);
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
