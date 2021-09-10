using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected abstract float _value { get; }

    public float Collect() {
        Destroy(gameObject);
        return _value;
    }
}
