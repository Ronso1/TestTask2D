using System.Collections;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _timeToDestroy;

    private IBulletBehavior behavior;

    public enum BulletType { Bouncing, Gravity }
    public BulletType bulletType;

    private void Start()
    {
        switch (bulletType)
        {
            case BulletType.Bouncing:
                behavior = new BouncingBulletBehavior();
                break;
            case BulletType.Gravity:
                behavior = new GravityBulletBehavior();
                break;
        }

        StartCoroutine(DestroyBulletByLifeTime());
        behavior?.Init(transform);
    }

    private void Update()
    {
        behavior?.Update();
    }

    private IEnumerator DestroyBulletByLifeTime()
    {
        yield return new WaitForSeconds(_timeToDestroy);
        Destroy(gameObject);
    }
}