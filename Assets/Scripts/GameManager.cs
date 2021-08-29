using UnityEngine;
using Pathfinding;

public class GameManager : MonoBehaviour
{
    public GameObject Enemy, Subject, MagicBullet;
    public Camera Camera;

    private float _gridGraphUpdateInterval = 10f;

    private void Awake()
    {
        var enemyGenerator = gameObject.AddComponent<EnemyGenerator>();
        enemyGenerator.Generateable = Enemy.GetComponent<Enemy>();
        enemyGenerator.Camera = Camera;
        enemyGenerator.Subject = Subject;
        InvokeRepeating("RecalculatePathGraphs", _gridGraphUpdateInterval, _gridGraphUpdateInterval);
        MagicBulletsShooter.MagicBulletObject = MagicBullet;
    }

    private void RecalculatePathGraphs()
    {
        AstarPath.active.data.gridGraph.center = Subject.transform.position;
        AstarPath.active.Scan();
    }
}
