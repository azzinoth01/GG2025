using UnityEngine;

public class EndGameTrigger : MonoBehaviour
{
    [SerializeField] private string _soundEvent;
    [SerializeField] private float _soundLength;

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.TryGetComponent(out Player collisionObject)) {

            if (_soundEvent != "") {
                GameObject playSoundAtPosition = new GameObject();
                playSoundAtPosition.transform.position = transform.position;
                DestroyAfterTime destroyAfterTime = playSoundAtPosition.AddComponent<DestroyAfterTime>();
                destroyAfterTime.DestroyTime = _soundLength;
                AkSoundEngine.PostEvent(_soundEvent, playSoundAtPosition);
            }

            GameManager.Instance.GameFinished();
        }
    }
}
