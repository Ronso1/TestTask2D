using UnityEngine;
using UnityEngine.InputSystem;

namespace Additions
{
    public class PlayerInput : MonoBehaviour
    {
        public event Event<Vector2> PlayerTouchStateChanged;
        public event Event<Vector2> PlayerTouchedScreen;

        private InputSystemActions _inputSystemActions;
        private Vector2 _cursorPosition;

        private void Awake()
        {
            _cursorPosition = new Vector2();
            _inputSystemActions = new InputSystemActions();
            _inputSystemActions.Enable();
        }

        private void OnEnable()
        {
            _inputSystemActions.PlayerMobile.TouchAction.started += OnPlayerTouchedScreen;
            _inputSystemActions.PlayerMobile.TouchPosition.performed += OnPlayerTouchScreen;
            _inputSystemActions.PlayerMobile.TouchPosition.canceled += OnPlayerStoppedTouchScreen;
        }


        private void OnDisable()
        {
            _inputSystemActions.PlayerMobile.TouchAction.started -= OnPlayerTouchedScreen;
            _inputSystemActions.PlayerMobile.TouchPosition.performed -= OnPlayerTouchScreen;
            _inputSystemActions.PlayerMobile.TouchPosition.canceled -= OnPlayerStoppedTouchScreen;
            _inputSystemActions.Disable();
        }
        private void OnPlayerTouchedScreen(InputAction.CallbackContext context)
        {
            _cursorPosition = _inputSystemActions.PlayerMobile.TouchPosition.ReadValue<Vector2>();
            PlayerTouchedScreen?.Invoke(_cursorPosition);
        }

        private void OnPlayerStoppedTouchScreen(InputAction.CallbackContext context)
        {
            
        }

        private void OnPlayerTouchScreen(InputAction.CallbackContext context)
        {
            _cursorPosition = _inputSystemActions.PlayerMobile.TouchPosition.ReadValue<Vector2>();
            PlayerTouchStateChanged?.Invoke(_cursorPosition);
        }
    }
}