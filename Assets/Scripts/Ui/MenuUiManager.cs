using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuUiManager : MonoBehaviour
{
    public GameObject ClassChoicePanel, ClassChoiceOption1, ClassChoiceOption2, SelectButton;
    public TextMeshProUGUI ClassName, ClassDescription;

    public void StartButtonAction()
    {
        ClassChoicePanel.SetActive(true);
        ClearOptionsSelection();
        ClassName.SetText("Choose your class");
        ClassDescription.SetText("");
    }

    public void GoBackToMainMenu() {
        ClassChoicePanel.SetActive(false);
    }

    public void ClearOptionsSelection() {
        ClassChoiceOption1.transform.Find("Image").GetComponent<Image>().color = Color.white;
        ClassChoiceOption2.transform.Find("Image").GetComponent<Image>().color = Color.white;
    }

    public void Select() {
    }
}
