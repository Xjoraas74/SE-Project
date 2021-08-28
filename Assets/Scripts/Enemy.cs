using UnityEngine;
using System.Collections;

public class Enemy : Generateable
{
    public float Cooldown = 0.36f;

    private const int _damage = 7;
    private bool canGiveDamage = true;

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

    private IEnumerator CooldownAttack()
    {
        yield return new WaitForSeconds(Cooldown);

        canGiveDamage = true;
    }
}
