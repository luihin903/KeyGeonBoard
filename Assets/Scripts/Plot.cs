using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using static Static;
using System.Linq;

public class Act0 : MonoBehaviour {
    
    public TextMeshProUGUI story;

    public int plot = 0;
    public bool loading = false;

    public GameObject rural;
    public GameObject castle;
    public GameObject dungeon;

    public Button choice1;
    public Button choice2;
    public Button title;

    public TextMeshProUGUI t1;
    public TextMeshProUGUI t2;
    public TextMeshProUGUI enter;
    public Button clickHere;

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
        "Princess: \"Could you bring me outside of this dungeon?\"",
        "You searched through the room, but you didn't see any human here.",
        "You realized that she was telling the truth.",
        "You decided to do so.",
        "You decided to kill the king.",
        "The door was locked, and you could hear soldiers chatting outside.",
        "Princess: \"Looks like he wants to trap us inside the dungeon.",
        "You are surrounded by 5 soldiers.",
        "You secretely left the dungeon and went to the castle.",
        "You fled the scene and ran towards the castle.",
        "You saw the knight was standing next to the king. You knew you need to kill the knight first.",
        "You stabbed your knife into the king's heart. He died.",
        "You became the new king of Ateb Kingdom and kept learning black magic everyday...",
        "The End"};

    void Start() {
        choice1.gameObject.SetActive(false);
        choice2.gameObject.SetActive(false);
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.Return)) {
            enterPressed();
        }

        story.text = plots[PlayerPrefs.GetInt("plot")];
        chooseBackground();
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
                rural.gameObject.SetActive(true);
                break;
            case 2:
                setP(3);
                rural.gameObject.SetActive(true);
                break;
            case 7:
                setP(8);
                show();
                t1.text = "\"Okay, bye then.\"";
                t2.text = "\"Why can't I?\"";
                break;
            case 8:
                setP(10);
                pp.setBool("ending3", true);
                rural.gameObject.SetActive(true);
                title.gameObject.SetActive(true);
                enter.gameObject.SetActive(false);
                clickHere.gameObject.SetActive(false);
                break;
            case 11:
                setP(13);
                break;
            case 15:
                setP(16);
                break;
            case 24:
                PlayerPrefs.SetInt("critical", 1);
                setP(25);
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
                pp.setBool("ending1", true);
                title.gameObject.SetActive(true);
                enter.gameObject.SetActive(false);
                clickHere.gameObject.SetActive(false);
                break;
            case 7:
                setP(9);
                pp.setBool("ending2", true);
                title.gameObject.SetActive(true);
                enter.gameObject.SetActive(false);
                clickHere.gameObject.SetActive(false);
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
            case 24:
                setP(26);
                PlayerPrefs.SetString("lastScene", "Plot");
                SceneManager.LoadScene("L1"); loading = true;
                break;
        }

    }

    public void enterPressed() { if(loading) return;
          
        switch (getP()) {
            case 0:
                setP(1);
                show();
                t1.text = "\"Sure, dad.\"";
                t2.text = "\"No way, I am not marrying someone I don\'t love.\"";
                break;
            case 3:
                // setP(5);
                setP(6);
                PlayerPrefs.SetString("lastScene", "Plot");
                PlayerPrefs.SetInt("firstWorld", 1);
                SceneManager.LoadScene("World"); loading = true;
                break;
            case 5:
                setP(6);
                PlayerPrefs.SetString("lastScene", "Plot");
                // SceneManager.LoadScene("Battle"); loading = true;
                PlayerPrefs.SetInt("firstWorld", 1);
                SceneManager.LoadScene("World"); loading = true;
                break;
            case 6:
                PlayerPrefs.SetInt("critical", 0);
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
                SceneManager.LoadScene("L1"); loading = true;
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
            case 17:
                setP(19);
                break;
            case 18:
                setP(21);
                break;
            case 19:
                setP(20);
                break;
            case 20:
                setP(22);
                break;
            case 21:
                setP(23);
                PlayerPrefs.SetString("lastScene", "Plot");
                PlayerPrefs.SetInt("dungeonLevel", 3);
                SceneManager.LoadScene("L3"); loading = true;
                break;
            case 22:
                setP(23);
                PlayerPrefs.SetString("lastScene", "Plot");
                PlayerPrefs.SetInt("dungeonLevel", 3);
                SceneManager.LoadScene("L3"); loading = true;
                break;
            case 23:
                setP(24);
                show();
                t1.text = "Break the door";
                t2.text = "Find another way";
                break;
            case 25:
                setP(27);
                PlayerPrefs.SetString("lastScene", "Plot");
                SceneManager.LoadScene("Battle"); loading = true;
                break;
            case 26:
                setP(29);
                break;
            case 27:
                setP(28);
                break;
            case 28:
                setP(29);
                PlayerPrefs.SetString("lastScene", "Plot");
                SceneManager.LoadScene("Battle"); loading = true;
                break;
            case 29:
                setP(30);
                break;
            case 30:
                setP(31);
                pp.setBool("ending4", true);
                title.gameObject.SetActive(true);
                enter.gameObject.SetActive(false);
                clickHere.gameObject.SetActive(false);
                break;
        }

    }

    public void Title() {
        SceneManager.LoadScene("Title"); loading = true;
    }

    private void show() {
        choice1.gameObject.SetActive(true);
        choice2.gameObject.SetActive(true);
        enter.gameObject.SetActive(false);
        clickHere.gameObject.SetActive(false);
    }

    private void hide() {
        choice1.gameObject.SetActive(false);
        choice2.gameObject.SetActive(false);
        enter.gameObject.SetActive(true);
        clickHere.gameObject.SetActive(true);
    }

    private void chooseBackground() {
        int[] castle = {0, 1, 2, 7, 8, 9, 11, 12, 28, 29, 30, 31};
        int[] rural = {3, 4, 5, 6, 10, 13};
        int[] dungeon = {14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27};

        // foreach (int i in castle) if (getP() == i) setCastle();
        // foreach (int i in rural) if (getP() == i) setRural();
        // foreach (int i in dungeon) if (getP() == i) setDungeon();
        if (castle.Contains(getP())) setCastle();
        else if (rural.Contains(getP())) setRural();
        else if (dungeon.Contains(getP())) setDungeon();
    }

    private void setCastle() {
        setActive(castle, true);
        setActive(rural, false);
        setActive(dungeon, false);
    }

    private void setRural() {
        setActive(rural, true);
        setActive(dungeon, false);
        setActive(castle, false);
    }

    private void setDungeon() {
        setActive(dungeon, true);
        setActive(castle, false);
        setActive(rural, false);
    }
}
