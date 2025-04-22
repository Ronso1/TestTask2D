using UnityEngine;
using UnityEngine.InputSystem;

namespace Additions
{
    public class PlayerInput : MonoBehaviour
    {
        private InputSystemActions _inputSystemActions;

        private void Awake()
        {
            _inputSystemActions = new InputSystemActions();
            _inputSystemActions.Enable();
        }

        private void OnEnable()
        {
            _inputSystemActions.PlayerMobile.Touch.performed += OnPlayerTouchScreen;
        }

        private void OnDisable()
        {
            _inputSystemActions.PlayerMobile.Touch.performed -= OnPlayerTouchScreen;
            _inputSystemActions.Disable();
        }

        private void OnPlayerTouchScreen(InputAction.CallbackContext context)
        {
            print("Hello");
        }
    }
}