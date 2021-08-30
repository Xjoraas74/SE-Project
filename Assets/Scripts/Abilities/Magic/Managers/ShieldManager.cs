using UnityEngine;

public class ShieldManager : MagicManager
{
    public static GameObject Shield;

    protected override float _cooldown { get => 3f; }

    protected override bool CanBeUsed() => Subject.Shield == null;

    protected override void Activate() {
        Subject.Shield = Instantiate(Shield, transform).GetComponent<Shield>();
    }
}
