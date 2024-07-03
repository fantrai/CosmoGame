using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractWeapon : AbstractShipElement
{
    public int Damage { get => damage; set => damage = value; }
    public float Speed { get => speed; set => speed = value; }
    public int Piercing { get => piercing; set => piercing = value; }
    public float Distance { get => distance; set => distance = value; }

    [SerializeField] AbstractBullet bulletPrefab;
    [SerializeField] int damage = 1;
    [SerializeField] float speed = 1f;
    [SerializeField] int piercing = 0;
    [SerializeField] float distance = 30;


    protected override void Effect()
    {
        AbstractBullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.Damage = damage;
        bullet.Speed = speed;
        bullet.Piercing = piercing;
        bullet.Distance = distance;
    }
}
