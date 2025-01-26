using UnityEngine;

public class DisolveObject : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _disolveTimeInSeconds;

    private float _disolveValue;

    private float _disolveState;

    private void OnEnable() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _disolveState = 0;
        _spriteRenderer.material.SetFloat("_DisolveState", _disolveState);

        _disolveValue = 1 / _disolveTimeInSeconds;
    }

    // Update is called once per frame
    void Update() {
        _disolveState = _disolveState + _disolveValue * Time.deltaTime;
        _spriteRenderer.material.SetFloat("_DisolveState", _disolveState);

        if (_disolveState >= 1) {
            gameObject.SetActive(false);
        }
    }
}
