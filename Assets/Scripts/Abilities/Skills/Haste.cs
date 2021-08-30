public class Haste : Skill
{
    protected override float _coefficient => 1.2f;

    protected override int _addendum => 0;

    protected override float GetTheOriginalValue() => _subject.Speed;

    public override void Apply() {
        _subject.Speed = GetRecalculatedValue();
    }
}
