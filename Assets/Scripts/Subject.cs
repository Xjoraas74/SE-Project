using UnityEngine;

public class Subject : MonoBehaviour
{
    public static int KillCount, Level = 1;

    public Joystick joystick;
    public UiManager UiManager;
    public float speed, controlInsensitivity;

    int _mp, points, _hp = 100, _hpMax = 100;
    private int _mpForLevel = 5;

    private void Start()
    {
        UiManager.UpdateMpBar(_mp, _mpForLevel);
        UiManager.UpdateHpBar(_hp, _hpMax);
    }

    void Update() {
        float horizontalMove, verticalMove;

        if (joystick.Horizontal >= controlInsensitivity) {
            horizontalMove = speed;
        } else if (joystick.Horizontal <= -controlInsensitivity) {
            horizontalMove = -speed;
        } else {
            horizontalMove = 0;
        }

        if (joystick.Vertical >= controlInsensitivity) {
           verticalMove = speed;
        } else if (joystick.Vertical <= -controlInsensitivity) {
            verticalMove = -speed;
        } else {
            verticalMove = 0;
        }

        transform.position += new Vector3(horizontalMove * Time.deltaTime, verticalMove * Time.deltaTime, 0);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        _hp -= other.GetComponent<Enemy>().GiveDamage();
        if (_hp > 0)
        {
            UiManager.UpdateHpBar(_hp, _hpMax);
        }
        else
        {
            UiManager.GiveUp();
        }
    }
}
