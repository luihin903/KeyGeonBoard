using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Static;

public class Status : MonoBehaviour {

    public Image status;
    public TMP_Text level;
    public TMP_Text hp;
    public TMP_Text atk;
    public TMP_Text def;
    public TMP_Text potion;
    public TMP_Text fire;
    public Button close;

    public bool open = false;

    void Update() {

        if (Input.GetKeyDown(KeyCode.Tab)) {
            
            Self prince = new Self();

            open = !open;
            status.gameObject.SetActive(open);

            level.text = "Lv. " + prince.level + " (" + prince.exp + "/" + prince.level*10 + ")";
            hp.text = "HP: " + prince.hp + "/" + prince.maxHp;
            if (pp.getBool("Chest 1")) {
                atk.text = "ATK: " + prince.atk;
            }
            else {
                atk.text = $"ATK: {prince.atk}+5";
            }
            def.text = "DEF: " + prince.def; 
            potion.text = "potion: heal yourself (" + pp.getInt("potion") + " left)";
            setActive(fire, !pp.getBool("Chest 2"));
        
        }

    }

    public void Close() {
        open = false;
        status.gameObject.SetActive(open);
    }

}