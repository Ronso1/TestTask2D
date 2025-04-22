using UnityEngine;

public interface IBulletBehavior
{
    void Init(Transform bulletTransform);
    void Update();
}