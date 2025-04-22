using UnityEngine;

public class BouncingBulletBehavior : IBulletBehavior
{
    private Vector2 _velocity;
    private float _bulletSpeed = 5f;
    private Camera _playerCamera;
    private Transform _bullet;

    public void Init(Transform bulletTransform)
    {
        _bullet = bulletTransform;
        _playerCamera = Camera.main;

        float angle = _bullet.eulerAngles.z * Mathf.Deg2Rad;
        _velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * _bulletSpeed;
    }

    public void Update()
    {
        _bullet.position += (Vector3)(_velocity * Time.deltaTime);
        CheckBounce();
    }

    private void CheckBounce()
    {
        Vector3 screenPos = _playerCamera.WorldToViewportPoint(_bullet.position);

        if (screenPos.x < 0f || screenPos.x > 1f)
        {
            _velocity.x = -_velocity.x;
            Clamp();
        }

        if (screenPos.y < 0f || screenPos.y > 1f)
        {
            _velocity.y = -_velocity.y;
            Clamp();
        }
    }

    private void Clamp()
    {
        Vector3 clamped = _playerCamera.WorldToViewportPoint(_bullet.position);
        clamped.x = Mathf.Clamp01(clamped.x);
        clamped.y = Mathf.Clamp01(clamped.y);
        _bullet.position = _playerCamera.ViewportToWorldPoint(clamped);
    }
}
