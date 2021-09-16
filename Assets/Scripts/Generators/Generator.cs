using UnityEngine;
using System.Collections;

public abstract class Generator : MonoBehaviour
{
    public GameObject Generateable;

    protected abstract float _initialDelay { get; }
    protected abstract float _usualDelay { get; }

    private static Camera _camera;
    private float _screenHalfDiag;

    private void Awake() {
        if (_camera == null) {
            _camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        }
    }

    private void Start()
    {
        float screenHalfHeight = _camera.orthographicSize, screenHalfWidth = screenHalfHeight * _camera.aspect;

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

    protected virtual GameObject Generate()
    {
        Vector3 randomPointWithinScreen = _camera.ScreenToWorldPoint(new Vector3(
            Random.Range(0, _camera.pixelWidth + 1),
            Random.Range(0, _camera.pixelHeight + 1),
            -_camera.transform.position.z
        ));
        Vector3 centerPointOnScreen = _camera.ScreenToWorldPoint(new Vector3(
            _camera.pixelWidth / 2,
            _camera.pixelHeight / 2,
            -_camera.transform.position.z
        ));
        Vector3 distanceFromCenter = randomPointWithinScreen - centerPointOnScreen;
        distanceFromCenter *= (_screenHalfDiag + 1) / distanceFromCenter.magnitude;
        Vector3 generatePosition = centerPointOnScreen + distanceFromCenter;

        return Instantiate(Generateable, generatePosition, Quaternion.identity);
    }
}
