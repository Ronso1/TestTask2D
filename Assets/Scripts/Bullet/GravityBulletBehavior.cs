using System.Collections;
using UnityEngine;

public class GravityBulletBehavior : IBulletBehavior
{
    private Vector2 _velocity;
    private float _initialSpeed = 5f;
    private float _gravity = -9.8f;
    private Transform _bullet;

    public void Init(Transform bulletTransform)
    {
        _bullet = bulletTransform;
        float angle = _bullet.eulerAngles.z * Mathf.Deg2Rad;
        _velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * _initialSpeed;
    }

    public void Update()
    {
        _velocity.y += _gravity * Time.deltaTime;
        _bullet.position += (Vector3)(_velocity * Time.deltaTime);
    }

    public IEnumerator BulletLife()
    {
        yield return null;
    }
}