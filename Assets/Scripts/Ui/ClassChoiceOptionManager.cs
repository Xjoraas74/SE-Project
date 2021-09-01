using UnityEngine;
using UnityEngine.UI;

public class ClassChoiceOptionManager : MonoBehaviour
{
    public MenuUiManager MenuUiManager;
    public string Name, Description;

    public void SelectOption() {
        MenuUiManager.ClearOptionsSelection();
        transform.Find("Image").GetComponent<Image>().color = Color.yellow;
        MenuUiManager.SelectButton.SetActive(true);
        MenuUiManager.ClassName.SetText(Name);
        MenuUiManager.ClassDescription.SetText(Description);
    }
}
