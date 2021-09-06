public class Attacker : SubjectClass
{
    protected override string _name => "Attacker";

    protected override string _description => "+1 magic bullet per charge";

    protected override void SetBoostedAbilitiesTypes()
    {
        _abilitiesTypes.Add(typeof(MagicBulletsManager));
    }
}
