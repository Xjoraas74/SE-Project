using UnityEngine;
using System.Collections;

public class MagicBulletsManager : MagicManager
{
    public override string Name { get => "Magic bullets"; }
    
    public override string Description { get => "+1 magic bullet"; }

    public static GameObject MagicBulletObject;
    public float SecondsBetweenCharges = .25f;

    protected override float _cooldown { get => 1f; }

    private bool _isShooting;

    private void Awake() {
        Level = 1;
    }

    protected override bool CanBeUsed() => EnemiesOnScreen.Count > 0 && !_isShooting;

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
        StartCoroutine(Shoot(angle, closestEnemyDirection.normalized));
    }

    private IEnumerator Shoot(float angle, Vector3 direction) {
        _isShooting = true;
        for (int i = 0; i < Level; i++) {
            var magicBullet = Instantiate(MagicBulletObject, transform.position, Quaternion.identity);
            var magicBulletRigidbody = magicBullet.GetComponent<Rigidbody2D>();
            magicBulletRigidbody.rotation = angle;
            magicBulletRigidbody.velocity = direction * MagicBullet.Speed;
            yield return new WaitForSeconds(SecondsBetweenCharges);
        }
        _isShooting = false;
    }
}
