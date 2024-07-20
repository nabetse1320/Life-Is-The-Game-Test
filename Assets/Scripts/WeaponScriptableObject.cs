using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New Weapon", menuName = "Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    public enum WeaponType { GravityWeapon, ParabolicWeapon, ExplosionWeapon}
    public WeaponType weaponType;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed;
    [Header("Explosion properties")]
    [SerializeField] private float explosionForce;
    [SerializeField] private float explosionRadius;
    [Header("Gravity Properties")]
    [SerializeField] private float influenceRangeGravity;
    [SerializeField] private float intensity;
    [Header("Parabolic properties")]
    [SerializeField] private float bulletUpSpeed;

    //General Properties
    public GameObject Bullet { get { return bullet; } }
    public float BulletSpeed { get { return bulletSpeed; } }
    //Explosion Properties
    public float ExplosionForce { get { return explosionForce; } }
    public float ExplosionRadius { get { return explosionRadius; } }
    //Gravity Properties
    public float InfluenceRangeGravity { get { return influenceRangeGravity; } }
    public float Intensity { get { return intensity; } }
    //Parabolic Properties
    public float BulletUpSpeed { get { return bulletUpSpeed; } }

}
