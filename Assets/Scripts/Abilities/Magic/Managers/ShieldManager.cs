using UnityEngine;

public class ShieldManager : MagicManager
{
    public override string Name { get => "Shield"; }
    
    public override string Description { get => "+1 shield charge"; }

    public static GameObject Shield;

    protected override float _cooldown { get => 3f; }

    protected override bool CanBeUsed() => Subject.Shield == null;

    protected override void Activate() {
        Subject.Shield = Instantiate(Shield, transform).GetComponent<Shield>();
        Subject.Shield.Charges = Level;
        Subject.Shield.MaxCharges = Level;
    }
}
