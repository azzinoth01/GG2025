using UnityEngine;

public class EndGameTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.TryGetComponent(out Player collisionObject)){
            GameManager.Instance.GameFinished();
        }  
    }
}
