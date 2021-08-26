using UnityEngine;

public class Subject : MonoBehaviour
{
    public Joystick joystick;
    public float speed, controlInsensitivity;

    int mp, hp, hpMax, points;
    double level;

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
