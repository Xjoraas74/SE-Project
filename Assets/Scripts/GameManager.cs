using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Enemy;
    public Camera Camera;

    private void Awake()
    {
        var enemyGenerator = gameObject.AddComponent<EnemyGenerator>();
        enemyGenerator.Generateable = Enemy.GetComponent<Enemy>();
        enemyGenerator.Camera = Camera;
    }
}
