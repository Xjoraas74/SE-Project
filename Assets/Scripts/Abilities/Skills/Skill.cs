public abstract class Skill : Ability
{
    protected Subject _subject;
    protected float _originalValue;
    protected abstract float _coefficient { get; }
    protected abstract int _addendum { get; }

    public override void Upgrade() {
        base.Upgrade();
        Apply();
    }

    protected void Awake() {
        _subject = gameObject.GetComponent<Subject>();
        _originalValue = GetTheOriginalValue();
    }

    protected abstract float GetTheOriginalValue();

    public abstract void Apply();

    protected float GetRecalculatedValue() {
        return _originalValue * ((_coefficient * Level) + 1) + _addendum;
    }
}
