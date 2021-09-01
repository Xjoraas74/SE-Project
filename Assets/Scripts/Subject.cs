using UnityEngine;
using System.Linq;

public class Subject : MonoBehaviour
{
    public static Shield Shield;
    public Joystick joystick;
    public GameUiManager UiManager;
    public float Speed, controlInsensitivity;
    public float HpMax = 100f;
    public int KillCount, Level = 1;

    private float _hp = 100, _mp;

    int points;

    private const float _mpForTheFirstLevel = 5f, _mpDiffBetweenAdjacentLevels = 1f;

    private void Awake() {
        var abilitiesTypes = typeof(Ability).Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(Ability)) && !type.IsAbstract);
        foreach(var abilityType in abilitiesTypes) {
            var ability = gameObject.AddComponent(abilityType) as Ability;
            if (ability.Level <= 0) {
                ability.enabled = false;
            }
        }
    }

    private void Start()
    {
        RecalculateHpBar();
        RecalculateMpBar();
    }

    void Update() {
        float horizontalMove, verticalMove;

        if (joystick.Horizontal >= controlInsensitivity) {
            horizontalMove = Speed;
        } else if (joystick.Horizontal <= -controlInsensitivity) {
            horizontalMove = -Speed;
        } else {
            horizontalMove = 0;
        }

        if (joystick.Vertical >= controlInsensitivity) {
           verticalMove = Speed;
        } else if (joystick.Vertical <= -controlInsensitivity) {
            verticalMove = -Speed;
        } else {
            verticalMove = 0;
        }

        transform.position += new Vector3(horizontalMove * Time.deltaTime, verticalMove * Time.deltaTime, 0);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy)) {
            ApplyDamage(enemy.GiveDamage());
            if (_hp > 0)
            {
                RecalculateHpBar();
            }
            else
            {
                UiManager.GiveUp();
            }
        }
    }

    private void ApplyDamage(int damage) {
        if (damage <= 0) {
            return;
        }
        if (Shield != null) {
            Shield.Protect();
            return;
        }
        else {
            _hp -= damage;
        }
    }

    public void RecalculateHpBar() {
        UiManager.UpdateHpBar(_hp, HpMax);
    }

    public void GetMpDrop(float mpDrop) {
        _mp += mpDrop;
        while(_mp > GetLevelStartingMp(Level + 1)) {
            UiManager.LevelUp();
            Level++;
        }
        RecalculateMpBar();
    }

    private void RecalculateMpBar() {
        UiManager.UpdateMpBar(GetLevelStartingMp(Level), _mp, GetLevelStartingMp(Level + 1));
    }

    private float GetMpDiffValueForLevelUp(int level) => level * (2 * _mpForTheFirstLevel + (level - 1) * _mpDiffBetweenAdjacentLevels) / 2;

    private float GetLevelStartingMp(int level) {
        if (level == 1) {
            return 0f;
        }
        else {
            return GetLevelStartingMp(level - 1) + GetMpDiffValueForLevelUp(level - 1);
        }
    }
}
