using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Magic : Ability
{
    public static List<Enemy> EnemiesOnScreen = new List<Enemy>();

    // the class diagram says it's the only universal field
    protected virtual float _cooldown { get; }
    private bool _didCoolDown = true;

    private int _damage;
    // also duration: float, numberOfCharges: int ?

    private void Start()
    {
        StartCoroutine(Use());
    }

    private IEnumerator Use() {
        while (true) {
            if (EnemiesOnScreen.Count > 0) { // if the magic can be used
                if (_didCoolDown) {
                    _didCoolDown = false;
                    Activate();
                }
                else {
                    yield return new WaitForSeconds(_cooldown);

                    _didCoolDown = true;
                }
            }
            else {
                yield return new WaitForEndOfFrame();
            }
        }
    }



    protected abstract void Activate();
}
