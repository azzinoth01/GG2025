using UnityEngine;
using UnityEngine.InputSystem;

public class GamepadInput : MonoBehaviour, PlayerAction.IGamepadInputActions
{
    private Player _player;


    public void OnAim(InputAction.CallbackContext context) {
        if (!GameManager.Instance.IsGamePaused()) {
            _player.Aim(context.ReadValue<Vector2>());
        }
    }

    public void OnMove(InputAction.CallbackContext context) {
        _player.Moving(context.ReadValue<Vector2>());
    }

    public void OnPause(InputAction.CallbackContext context) {
        if (context.started) {
            _player.Pause();
        }

    }

    public void OnShoot(InputAction.CallbackContext context) {
        if (context.started) {
            _player.Shoot();
        }
    }

    private void Start() {
        _player = GetComponent<Player>();
    }

}
