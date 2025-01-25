
using System.Collections.Generic;
using UnityEngine;

public class TriggerGameStart : MonoBehaviour
{
    [SerializeField] private List<GameObject> _activateObjects;
    [SerializeField] private List<GameObject> _destroyObjects;
    [SerializeField] private DisolveObject _disolveObject;

    private void OnTriggerEnter2D(Collider2D collision) {
        foreach (GameObject activateObject in _activateObjects) {
            activateObject.SetActive(true);
        }
        foreach (GameObject destroyObject in _destroyObjects) {
            Destroy(destroyObject);
        }
        _disolveObject.enabled = true;
    }
}
