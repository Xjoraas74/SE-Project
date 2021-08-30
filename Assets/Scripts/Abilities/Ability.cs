using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    private int _level, _maxLevel;
    protected virtual bool _isUpgradeable { get => true; }
    
    public void Upgrade() {

    }
}
