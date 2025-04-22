using UnityEngine;
using Additions;

namespace Gun
{
    public class GunLogic : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private Camera _camera;

        [SerializeField] private float _offset;

        private void OnEnable()
        {
            _playerInput.PlayerTouchStateChanged += OnWeaponStartRotate;
        }

        private void OnDisable()
        {
            _playerInput.PlayerTouchStateChanged -= OnWeaponStartRotate;
        }

        private void OnWeaponStartRotate(Vector2 touchPosition)
        {
            var worldPosition = _camera.ScreenToWorldPoint(touchPosition);
            var direction = worldPosition - transform.position;

            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + _offset;

            transform.localRotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}