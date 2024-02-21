using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

    public Image dark;

    public TMP_Text tutorialSlimeText;
    public Image tutorialSlimeArrow;
    public Image tutorialSlimeImage;
    public Button tutorialSlimeButton;

    public TMP_Text tutorialEnemyHpText;
    public Image tutorialEnemyHpArrow;
    public Slider tutorialEnemyHpImage;
    public Button tutorialEnemyHpButton;

    public TMP_Text tutorialPrinceHpText;
    public Image tutorialPrinceHpArrow;
    public Slider tutorialPrinceHpImage;
    public TMP_Text tutorialPrinceHpImageText;
    public Button tutorialPrinceHpButton;

    public TMP_Text tutorialActionText;
    public Image tutorialActionArrow;
    public TMP_InputField tutorialActionImage;
    public bool finished = false;

    public TMP_InputField realInput;

    void Start() {

        dark.gameObject.SetActive(true);

        tutorialSlimeText.gameObject.SetActive(true);
        tutorialSlimeArrow.gameObject.SetActive(true);
        tutorialSlimeImage.gameObject.SetActive(true);
        tutorialSlimeButton.gameObject.SetActive(true);

        tutorialEnemyHpText.gameObject.SetActive(false);
        tutorialEnemyHpArrow.gameObject.SetActive(false);
        tutorialEnemyHpImage.gameObject.SetActive(false);
        tutorialEnemyHpButton.gameObject.SetActive(false);

        tutorialPrinceHpText.gameObject.SetActive(false);
        tutorialPrinceHpArrow.gameObject.SetActive(false);
        tutorialPrinceHpImage.gameObject.SetActive(false);
        tutorialPrinceHpImageText.gameObject.SetActive(false);
        tutorialPrinceHpButton.gameObject.SetActive(false);

        tutorialActionText.gameObject.SetActive(false);
        tutorialActionArrow.gameObject.SetActive(false);
        tutorialActionImage.gameObject.SetActive(false);
    }

    void Update() {
        if (finished) {
            if (Input.anyKeyDown) {
                dark.gameObject.SetActive(false);
                
                tutorialActionText.gameObject.SetActive(false);
                tutorialActionArrow.gameObject.SetActive(false);
                tutorialActionImage.gameObject.SetActive(false);
            }
        }
    }

    public void TutorialSlimeButton() {
        tutorialSlimeText.gameObject.SetActive(false);
        tutorialSlimeArrow.gameObject.SetActive(false);
        tutorialSlimeImage.gameObject.SetActive(false);
        tutorialSlimeButton.gameObject.SetActive(false);
        
        tutorialEnemyHpText.gameObject.SetActive(true);
        tutorialEnemyHpArrow.gameObject.SetActive(true);
        tutorialEnemyHpImage.gameObject.SetActive(true);
        tutorialEnemyHpButton.gameObject.SetActive(true);
    }

    public void TutorialEnemyHpButton() {

        tutorialEnemyHpText.gameObject.SetActive(false);
        tutorialEnemyHpArrow.gameObject.SetActive(false);
        tutorialEnemyHpImage.gameObject.SetActive(false);
        tutorialEnemyHpButton.gameObject.SetActive(false);

        tutorialPrinceHpText.gameObject.SetActive(true);
        tutorialPrinceHpArrow.gameObject.SetActive(true);
        tutorialPrinceHpImage.gameObject.SetActive(true);
        tutorialPrinceHpImageText.gameObject.SetActive(true);
        tutorialPrinceHpButton.gameObject.SetActive(true);

    }

    public void TutorialPrinceHpButton() {

        tutorialPrinceHpText.gameObject.SetActive(false);
        tutorialPrinceHpArrow.gameObject.SetActive(false);
        tutorialPrinceHpImage.gameObject.SetActive(false);
        tutorialPrinceHpImageText.gameObject.SetActive(false);
        tutorialPrinceHpButton.gameObject.SetActive(false);

        tutorialActionText.gameObject.SetActive(true);
        tutorialActionArrow.gameObject.SetActive(true);
        tutorialActionImage.gameObject.SetActive(true);
        finished = true;
        realInput.Select();

    }

}