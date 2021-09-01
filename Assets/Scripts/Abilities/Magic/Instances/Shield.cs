using UnityEngine;

public class Shield : MonoBehaviour
{
    public Gradient Gradient;
    public int Charges, MaxCharges;

    private void Start() {
        SetColor();
    }

    public void Protect() {
        Charges--;
        if (Charges <= 0) {
            Destroy(gameObject);
        }
        else {
            SetColor();
        }
    }

    private void SetColor() {
        GetComponent<SpriteRenderer>().color = Gradient.Evaluate((float)Charges / MaxCharges);
    }
}
