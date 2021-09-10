using UnityEngine;
using Pathfinding;

public class GameManager : MonoBehaviour
{
    public GameObject Subject;
    public GameObject MagicBullet, Shield;

    private float _gridGraphUpdateInterval = 10f;

    private void Awake()
    {
        FillMagicManagersReferences();
        InvokeRepeating("RecalculatePathGraphs", _gridGraphUpdateInterval, _gridGraphUpdateInterval);
    }

    private void RecalculatePathGraphs()
    {
        AstarPath.active.data.gridGraph.center = Subject.transform.position;
        AstarPath.active.Scan();
    }

    private void FillMagicManagersReferences() {
        MagicBulletsManager.MagicBulletObject = MagicBullet;
        ShieldManager.Shield = Shield;
    }
}
