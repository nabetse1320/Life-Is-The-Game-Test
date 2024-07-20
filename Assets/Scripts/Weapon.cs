using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform shootingPoint;
    [SerializeField] WeaponScriptableObject weapon;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && GetWeapon.weapon == this.gameObject)
        {
            var _bullet = Instantiate(weapon.Bullet, shootingPoint.position, shootingPoint.rotation);
            _bullet.GetComponent<Rigidbody>().velocity = weapon.BulletSpeed * shootingPoint.forward;
            switch (weapon.weaponType.ToString())
            {
                case "GravityWeapon":

                    _bullet.GetComponent<Bullet>().CreateGravityBullet(weapon.Intensity, weapon.InfluenceRangeGravity);
                    break;

                case "ParabolicWeapon":

                    _bullet.GetComponent<Rigidbody>().AddForce(shootingPoint.up * weapon.BulletUpSpeed, ForceMode.Impulse);
                    break;

                case "ExplosionWeapon":

                    _bullet.GetComponent<Bullet>().CreateExplosionBullet(weapon.ExplosionForce, weapon.ExplosionRadius);
                    break;
            }
        }
    }
}
