using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CannonGun : IWeapon
{

    [SerializeField] private BulletController bulletPrefab;
    private IObjectPool<BulletController> bulletPool;

    private void Awake()
    {
        bulletPool = new ObjectPool<BulletController>(() =>
        {
            BulletController bullet = Instantiate(bulletPrefab);
            bullet.InIt(KillObjectInPool);

            return bullet;
        }
    , bullet => bullet.gameObject.SetActive(true)
    , bullet => bullet.gameObject.SetActive(false)
    , bullet => Destroy(bullet.gameObject)
    , false, 20);
    }

    private void KillObjectInPool(BulletController bullet)
    {
        bulletPool.Release(bullet);
    }

    public override void ExcuteAttack()
    {
        BulletController bullet = bulletPool.Get();

        bullet.transform.forward = transform.forward;
        bullet.transform.position = transform.position;
    }
}
