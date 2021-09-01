public class Haste : Skill
{
    public override string Name { get => "Haste"; }

    public override string Description { get => "Movement speed + 20%"; }

    protected override float _coefficient => 0.2f;

    protected override int _addendum => 0;

    protected override float GetTheOriginalValue() => _subject.Speed;

    public override void Apply() {
        _subject.Speed = GetRecalculatedValue();
    }
}
