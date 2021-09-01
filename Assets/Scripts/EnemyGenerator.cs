using UnityEngine;
using Pathfinding;

public class EnemyGenerator : Generator
{
    public GameObject Subject;

    protected override float _initialDelay { get => 1.5f; }
    protected override float _usualDelay { get => 0.25f; }

    protected override Generateable Generate()
    {
        Generateable baseForm = base.Generate();
        baseForm.GetComponent<AIDestinationSetter>().target = Subject.transform;
        return baseForm;
    }
}
