using UnityEngine;
using Additions;

namespace Gun
{
    public class GunLogic : MonoBehaviour
    {
        [Header("Links to references")]
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private Camera _camera;
        [Header("Parameters")]
        [SerializeField] private float _minClamp;
        [SerializeField] private float _maxClamp;

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
            const float offset = -90f;

            var worldPosition = _camera.ScreenToWorldPoint(touchPosition);
            var direction = worldPosition - transform.position;

            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + offset;            
            angle = Mathf.Clamp(angle, _minClamp, _maxClamp);

            if (angle <= _minClamp || angle >= _maxClamp) return;

            transform.localRotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}