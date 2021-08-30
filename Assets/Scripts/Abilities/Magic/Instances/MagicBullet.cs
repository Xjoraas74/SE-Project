using UnityEngine;

public class MagicBullet : MonoBehaviour
{
    public static float Speed = 3f;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.TryGetComponent(out Enemy enemy)) {
            enemy.GetDamage(11);
            Destroy(gameObject);
        }
    }
}
