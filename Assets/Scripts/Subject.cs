using UnityEngine;

public class Subject : MonoBehaviour
{
    public Joystick joystick;
    public float speed, controlInsensitivity;
    public static int KillCount, Level = 1;

    int mp, hp, hpMax, points;

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
}
