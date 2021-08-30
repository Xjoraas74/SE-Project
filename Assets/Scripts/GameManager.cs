using UnityEngine;
using Pathfinding;

public class GameManager : MonoBehaviour
{
    public GameObject Enemy, Subject;
    public GameObject MagicBullet, Shield;
    public Camera Camera;

    private float _gridGraphUpdateInterval = 10f;

    private void Awake()
    {
        FillGeneratorsReferences();
        FillMagicManagersReferences();
        InvokeRepeating("RecalculatePathGraphs", _gridGraphUpdateInterval, _gridGraphUpdateInterval);
    }

    private void FillGeneratorsReferences() {
        var enemyGenerator = gameObject.AddComponent<EnemyGenerator>();
        enemyGenerator.Generateable = Enemy.GetComponent<Enemy>();
        enemyGenerator.Camera = Camera;
        enemyGenerator.Subject = Subject;
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
