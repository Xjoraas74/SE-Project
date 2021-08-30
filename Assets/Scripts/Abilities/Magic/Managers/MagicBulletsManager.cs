using UnityEngine;

public class MagicBulletsManager : MagicManager
{
    public static GameObject MagicBulletObject;

    protected override float _cooldown { get => 1f; }

    protected override bool CanBeUsed() => EnemiesOnScreen.Count > 0;

    protected override void Activate() {
        // get the closest enemy
        Vector3 closestEnemyDirection = EnemiesOnScreen[0].transform.position - transform.position;
        foreach (var enemy in EnemiesOnScreen) {
            var direction = enemy.transform.position - transform.position;
            if (closestEnemyDirection.magnitude > direction.magnitude) {
                closestEnemyDirection = direction;
            }
        }

        // get the proper rotation to it
        float angle = Mathf.Atan2(closestEnemyDirection.y, closestEnemyDirection.x) * Mathf.Rad2Deg - 90f;
        
        // use this rotation
        var magicBullet = Instantiate(MagicBulletObject, transform.position, Quaternion.identity);
        var magicBulletRigidbody = magicBullet.GetComponent<Rigidbody2D>();
        magicBulletRigidbody.rotation = angle;
        magicBulletRigidbody.velocity = closestEnemyDirection.normalized * MagicBullet.Speed;
    }
}
