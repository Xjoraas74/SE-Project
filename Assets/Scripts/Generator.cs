using UnityEngine;
using System.Collections;

public abstract class Generator : MonoBehaviour
{
    public Generateable Generateable;
    public Camera Camera;

    protected abstract float _initialDelay { get; }
    protected abstract float _usualDelay { get; }

    private float _screenHalfDiag;

    private void Start()
    {
        float screenHalfHeight = Camera.orthographicSize, screenHalfWidth = screenHalfHeight * Camera.aspect;

        _screenHalfDiag = Mathf.Sqrt(screenHalfWidth * screenHalfWidth + screenHalfHeight * screenHalfHeight);
        StartCoroutine(GenerateCoroutine());
    }

    private IEnumerator GenerateCoroutine()
    {
        yield return new WaitForSeconds(_initialDelay);

        while (true)
        {
            Generate();
            yield return new WaitForSeconds(_usualDelay);
        }
    }

    protected virtual Generateable Generate()
    {
        Vector3 randomPointWithinScreen = Camera.ScreenToWorldPoint(new Vector3(
            Random.Range(0, Camera.pixelWidth + 1),
            Random.Range(0, Camera.pixelHeight + 1),
            -Camera.transform.position.z
        ));
        Vector3 centerPointOnScreen = Camera.ScreenToWorldPoint(new Vector3(
            Camera.pixelWidth / 2,
            Camera.pixelHeight / 2,
            -Camera.transform.position.z
        ));
        Vector3 distanceFromCenter = randomPointWithinScreen - centerPointOnScreen;
        distanceFromCenter *= (_screenHalfDiag + 1) / distanceFromCenter.magnitude;
        Vector3 generatePosition = centerPointOnScreen + distanceFromCenter;

        return Instantiate(Generateable, generatePosition, Quaternion.identity);
    }
}
