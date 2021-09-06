using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MenuUiManager : MonoBehaviour
{
    public GameObject ClassChoicePanel, SelectButton;
    public TextMeshProUGUI ClassName, ClassDescription;

    private List<GameObject> _classes;

    public void StartButtonAction()
    {
        ClassChoicePanel.SetActive(true);
        _classes = new List<GameObject>();
        foreach(Transform child in ClassChoicePanel.transform) {
            if (child.tag == "ClassOption") {
                _classes.Add(child.gameObject);
            }
        }
        ClearOptionsSelection();
        ClassName.SetText("Choose your class");
        ClassDescription.SetText("");
    }

    public void GoBackToMainMenu() {
        ClassChoicePanel.SetActive(false);
    }

    public void ClearOptionsSelection() {
        foreach (var _class in _classes) {
            _class.transform.Find("Image").GetComponent<Image>().color = Color.white;
        }
    }

    public void Select() {
        foreach (var _class in _classes) {
            if (_class.transform.Find("Image").GetComponent<Image>().color != Color.white) {
                var optionManager = _class.GetComponent<ClassChoiceOptionManager>();
                
                // disable here all option buttons before the scene transitions if the selected button visibly disappears
                optionManager.PrepareForSceneTransition();

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
