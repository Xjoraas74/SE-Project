using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public abstract string Name { get; }
    public virtual string Description { get; }
    public int Level = 0;
    public virtual bool IsUpgradeable { get => true; set => IsUpgradeable = value; }

    protected int _maxLevel = int.MaxValue;
    
    public virtual void Upgrade() {
        Level++;
        if (Level > 0) {
            this.enabled = true;
        }
        if (Level >= _maxLevel) {
            IsUpgradeable = false;
        }
    }
}
