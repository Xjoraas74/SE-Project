using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class ClassChoiceOptionManager : MonoBehaviour
{
    public MenuUiManager MenuUiManager;
    
    private List<Type> _abilitiesTypes;
    private string _name, _description;

    public void SetupOption(List<Type> abilitiesTypes, string name, string description) {
        _abilitiesTypes = abilitiesTypes;
        _name = name;
        _description = description;
    }

    public void SelectOption() {
        MenuUiManager.ClearOptionsSelection();
        transform.Find("Image").GetComponent<Image>().color = Color.yellow;
        MenuUiManager.SelectButton.SetActive(true);
        MenuUiManager.ClassName.SetText(_name);
        MenuUiManager.ClassDescription.SetText(_description);
    }

    public void PrepareForSceneTransition() {
        transform.SetParent(null, false);
        DontDestroyOnLoad(gameObject);
    }

    public (List<Type> abilitiesTypes, Sprite sprite) GetSubjectClassData() {
        Destroy(gameObject);
        return (_abilitiesTypes, transform.Find("Image").GetComponent<Image>().sprite);
    }
}
