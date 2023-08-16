using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

//public class CannonGun : IWeapon
//{

//    [SerializeField] private ProjectileController bulletPrefab;
//    private IObjectPool<ProjectileController> bulletPool;

//    private void Awake()
//    {
//        bulletPool = new ObjectPool<ProjectileController>(() =>
//        {
//            ProjectileController bullet = Instantiate(bulletPrefab);
//            bullet.InIt(KillObjectInPool);

//            return bullet;
//        }
//    , bullet => bullet.gameObject.SetActive(true)
//    , bullet => bullet.gameObject.SetActive(false)
//    , bullet => Destroy(bullet.gameObject)
//    , false, 20);
//    }

//    private void KillObjectInPool(ProjectileController bullet)
//    {
//        bulletPool.Release(bullet);
//    }

//    public  void ExcuteAttack()
//    {
//        //ProjectileController bullet = bulletPool.Get();

//        //bullet.transform.forward = transform.forward;
//        //bullet.transform.position = transform.position;
//    }

//    private void OnDestroy()
//    {

//    }
//}
