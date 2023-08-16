using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private Transform weaponHolder;

    private IObjectPool<ProjectileController> bulletPool;

    private bool canExcuteAttack;
    private void Start()
    {
        OnWeaponEquip();
        canExcuteAttack = true;
        bulletPool = new ObjectPool<ProjectileController>(() =>
        {
            ProjectileController bullet = Instantiate(weapon.projectilePrefab);
            bullet.InIt(KillObjectInPool);

            return bullet;
        }
        , bullet => bullet.gameObject.SetActive(true)
        , bullet => bullet.gameObject.SetActive(false)
        , bullet => Destroy(bullet.gameObject)
        , false, 20);

    }

    private void KillObjectInPool(ProjectileController bullet)
    {
        if (bullet.projectile.id == weapon.projectilePrefab.projectile.id)
        {
            bulletPool.Release(bullet);
        }
        else
        {
            Destroy(bullet.gameObject);
        }
    }


    public void ExcuteAttack(InputAction.CallbackContext context)
    {
        if (context.performed && canExcuteAttack)
        {
            Debug.Log("attack");
            ProjectileController bullet = bulletPool.Get();

            bullet.transform.forward = transform.forward;
            bullet.transform.position = transform.position;

            StartCoroutine(AttackCountdown());
        }
    }

    private IEnumerator AttackCountdown()
    {
        canExcuteAttack = false;
        yield return new WaitForSeconds(weapon.cooldownTime);
        canExcuteAttack = true;
    }

    public void EquipWeapon( Weapon weapon)
    {
        this.weapon = weapon;
        bulletPool.Clear();
    }

    private void OnWeaponEquip()
    {
        for (var i = weaponHolder.childCount - 1; i >= 0; i--)
        {
            // only destroy tagged object
                Destroy(weaponHolder.GetChild(i).gameObject);
        }

        GameObject newWeapon = Instantiate(weapon.weaponPrefab,weaponHolder);
    }
}
