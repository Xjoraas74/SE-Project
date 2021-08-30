using UnityEngine;

public class Subject : MonoBehaviour
{
    public static int KillCount, Level = 1;

    public static Shield Shield;
    public Joystick joystick;
    public UiManager UiManager;
    public float Speed, controlInsensitivity;
    public float HpMax = 100f;

    private float _hp = 100;

    int _mp, points;
    private int _mpForLevel = 5;

    private void Start()
    {
        UiManager.UpdateMpBar(_mp, _mpForLevel);
        RecalculateHpBar();

        gameObject.AddComponent<MagicBulletsManager>();
        gameObject.AddComponent<ShieldManager>();
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

    public void GetMpDrop(int mpDrop) {
        _mp += mpDrop;
        UiManager.UpdateMpBar(_mp, _mpForLevel);
    }
}
