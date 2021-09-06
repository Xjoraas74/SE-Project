using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class SubjectClass : MonoBehaviour
{
    protected List<Type> _abilitiesTypes = new List<Type>();
    protected abstract string _name { get; }
    protected abstract string _description { get; }

    private void Awake() {
        SetBoostedAbilitiesTypes();
        GetComponent<ClassChoiceOptionManager>().SetupOption(_abilitiesTypes, _name, _description);
    }

    protected abstract void SetBoostedAbilitiesTypes();
}
