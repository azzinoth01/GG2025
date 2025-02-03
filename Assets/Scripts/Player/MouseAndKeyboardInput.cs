using UnityEngine;
using UnityEngine.InputSystem;

public class MouseAndKeyboardInput : MonoBehaviour, PlayerAction.IMouseAndKeyboardInputActions
{
    private Player _player;

    public void OnAim(InputAction.CallbackContext context) {
        Vector2 mousePosition = context.ReadValue<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 playerPosition = transform.position;
        Vector2 aimDirection = (mousePosition - playerPosition).normalized;
        _player.Aim(aimDirection);
    }

    public void OnMove(InputAction.CallbackContext context) {
        _player.Moving(context.ReadValue<Vector2>());
    }

    public void OnPause(InputAction.CallbackContext context) {
        if(context.started) {
            _player.Pause();
        }
    }

    public void OnShoot(InputAction.CallbackContext context) {
        if(context.started) {
            _player.Shoot();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        _player = gameObject.GetComponent<Player>();
    }

    public void ChangeInputControls(PlayerInput playerInput) {
        if(playerInput.currentControlScheme == "MouseAndKeyboard") {
            playerInput.SwitchCurrentActionMap("MouseAndKeyboardInput");
        }
    }
}
