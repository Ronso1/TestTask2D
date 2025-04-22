using System.Collections;
using UnityEngine;
using GameUI;

namespace Bullet
{
    public class BulletLogic : MonoBehaviour
    {
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private float _timeToDestroy;

        private SwapGunLogic _swapGunLogic;

        private IBulletBehavior behavior;

        public enum BulletType { Bouncing, Gravity }
        public BulletType bulletType;

        private void Awake()
        {
            _swapGunLogic = GameObject.FindObjectOfType<SwapGunLogic>();
        }

        private void Start()
        {
            switch (_swapGunLogic.CurrentState)
            {
                case 0:
                    behavior = new BouncingBulletBehavior();
                    break;
                case 1:
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
}
