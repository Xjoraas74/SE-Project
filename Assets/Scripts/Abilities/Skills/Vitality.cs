using System.Collections.Generic;

public class Vitality : Skill
{
    public override string Name { get => "Vitality"; }
    
    public override string Description { get => "Max HP + 50%"; }

    protected override float _coefficient => 0.5f;

    protected override int _addendum => 0;

    protected override float GetTheOriginalValue() => _subject.HpMax;

    public override void Apply() {
        _subject.HpMax = GetRecalculatedValue();
        _subject.RecalculateHpBar();
    }
}
