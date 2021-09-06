public class Tank : SubjectClass
{
    protected override string _name => "Tank";

    protected override string _description => "+1 shield charge";

    protected override void SetBoostedAbilitiesTypes()
    {
        _abilitiesTypes.Add(typeof(ShieldManager));
    }
}
