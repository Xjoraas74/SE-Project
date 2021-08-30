using UnityEngine;
using System.Collections;
using Pathfinding;

public class Enemy : Generateable
{
    public float Cooldown = 0.36f;

    private const int _damage = 7;
    private bool canGiveDamage = true;
    private int _hp = 10, _mpDrop = 1;

    private void OnBecameVisible()
    {
        MagicManager.EnemiesOnScreen.Add(this);
    }

    private void OnBecameInvisible()
    {
        MagicManager.EnemiesOnScreen.Remove(this);
    }

    public int GiveDamage()
    {
        if (canGiveDamage)
        {
            canGiveDamage = false;
            StartCoroutine(CooldownAttack());
            return _damage;
        }
        else
        {
            return 0;
        }
    }

    public void GetDamage(int damage) {
        _hp -= damage;
        if (_hp <= 0) {
            GetComponent<AIDestinationSetter>().target.gameObject.GetComponent<Subject>().GetMpDrop(_mpDrop);
            Destroy(gameObject);
        }
    }

    private IEnumerator CooldownAttack()
    {
        yield return new WaitForSeconds(Cooldown);

        canGiveDamage = true;
    }
}
