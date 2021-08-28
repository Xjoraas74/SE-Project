using UnityEngine;

public class EnemyGenerator : Generator
{
    protected override float _initialDelay { get => 1.5f; }
    protected override float _usualDelay { get => 0.5f; }
}
