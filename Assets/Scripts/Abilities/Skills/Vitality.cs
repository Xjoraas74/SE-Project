using System.Collections.Generic;

public class Vitality : Skill
{
    protected override float _coefficient => 1.5f;

    protected override int _addendum => 0;

    protected override float GetTheOriginalValue() => _subject.HpMax;

    public override void Apply() {
        _subject.HpMax = GetRecalculatedValue();
        _subject.RecalculateHpBar();
    }
}
